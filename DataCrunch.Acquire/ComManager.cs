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
        
        public ComManager(string portName, ArduinoSampleParser sampleParser, Action<Sample, Sample> updateChart)
        {
            accumulated = new Sample();
            accumulatedTwo = new Sample();
                        
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
                    
                    SmoothingFunction(lastSample, ref smoothedValue, 0.2);
                    
                    //updateChart(accumulated);
                    accumulated = accumulated + (lastSample - smoothedValue);
                    SmoothingFunction(accumulated, ref smoothAccumulated, 0.2);
                    accumulatedTwo = accumulatedTwo + ( accumulated - smoothAccumulated);

                    updateChart(accumulated, lastSample);
                    //updateChart(lastSample);
                    
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
