using System;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.IO.Ports;
using DataCrunch.Acquire.Exceptions;
using System.Linq.Expressions;

namespace DataCrunch.Acquire
{
    public class ComManager : IDisposable
    {
        private SerialPort mySerialPort;
        private Sample smoothedValue;

        private Sample accumulated;
        private Sample smoothAccumulated;
        private Sample accumulatedTwo;

        private List<RowingSignal> horizontalSignals;
        //private List<RowingSignal> verticalSignals;

        private int HORIZONTAL_SIGNAL_THRESHOLD = 3000;
        
        public ComManager(string portName, ArduinoSampleParser sampleParser, Action<Sample, Sample, RowingSignal> updateChart)
        {
            accumulated = new Sample();
            accumulatedTwo = new Sample();
            horizontalSignals = new List<RowingSignal>();

            mySerialPort = new SerialPort("COM5");

            mySerialPort.BaudRate = 38400;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler((sender, e) => {
                try
                {
                    SerialPort sp = (SerialPort)sender;
                    string lastRead = sp.ReadLine();
                    Sample lastSample = sampleParser.Parse(lastRead);

                    RowingSignal signal = null;
                    const int STROKE_RATE_SMOOTHING = 5;
                    double strokeTime = -1;
                    DateTime signalTime = DateTime.Now;
                    if (lastSample.a >= HORIZONTAL_SIGNAL_THRESHOLD &&
                        ((horizontalSignals.LastOrDefault() != null && horizontalSignals.Last().Phase == RowingPhases.Catch) 
                            || horizontalSignals.LastOrDefault() == null)
                    )
                    {
                        
                        var lastRelease = horizontalSignals.LastOrDefault(s => s.Phase == RowingPhases.Release);
                        if(lastRelease != null)
                        {
                            strokeTime = (signalTime - lastRelease.TimeStamp).TotalMilliseconds;
                        }

                        
                        signal = new RowingSignal { TimeStamp = signalTime, Phase = RowingPhases.Release, StrokeTime = strokeTime };
                        horizontalSignals.Add(signal);
                    }
                    else if (lastSample.a <= -HORIZONTAL_SIGNAL_THRESHOLD &&
                                ((horizontalSignals.LastOrDefault() != null &&  horizontalSignals.Last().Phase == RowingPhases.Release) 
                                    || horizontalSignals.LastOrDefault() == null))
                    {
                        var lastCatch = horizontalSignals.LastOrDefault(s => s.Phase == RowingPhases.Catch);
                        if(lastCatch != null)
                        {
                            strokeTime = (signalTime - lastCatch.TimeStamp).TotalMilliseconds;
                        }

                        signal = new RowingSignal { TimeStamp = signalTime, Phase = RowingPhases.Catch, StrokeTime = strokeTime };
                        horizontalSignals.Add(signal);
                    }
                    
                    if (horizontalSignals.Count >= STROKE_RATE_SMOOTHING)
                    {
                        var smoothedStrokeRate = horizontalSignals.OrderByDescending(s => s.TimeStamp).Take(STROKE_RATE_SMOOTHING).Average(s => 60000 / s.StrokeTime);
                        horizontalSignals.Last().SmoothedStrokeRate = smoothedStrokeRate;
                    }



                    SmoothingFunction(lastSample, ref smoothedValue, 0.97);
                    
                    accumulated = accumulated + (lastSample - smoothedValue);
                    SmoothingFunction(accumulated, ref smoothAccumulated, 0.97);
                    accumulatedTwo = accumulatedTwo + ( accumulated - smoothAccumulated);

                    updateChart(accumulated, lastSample, signal);
                    
                }
                catch (InvalidFormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            mySerialPort.Open();
        }
        

        private void SmoothingFunction(Sample s, ref Sample smoothed, double smoothingCoefficient)
        {
            if (smoothed != null)
            {
                for (int i = 0; i < s.parts.Length; i++)
                {
                    smoothed.parts[i] = (int)(smoothed.parts[i] - (smoothingCoefficient * (smoothed.parts[i] - s.parts[i])));
                }
            }
            else
            {
                smoothed = s;
            }
        }

        public void Dispose()
        {
            if(mySerialPort != null)
            {
                mySerialPort.Dispose();
            }
        }

        public List<ComPortInfo> GetComPorts()
        {
            List<ComPortInfo> portList = new List<ComPortInfo>();

            using (var searcher = new ManagementObjectSearcher
                ("SELECT * FROM WIN32_SerialPort"))
            {
                string[] portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList();
                var tList = (from n in portnames
                             join p in ports on n equals p["DeviceID"].ToString()
                             select n + " - " + p["Caption"]).ToList();

                foreach (string s in tList)
                {
                    portList.Add(new ComPortInfo { PortDescription = s });
                }
            }

            return portList;
        }
        
    }
}
