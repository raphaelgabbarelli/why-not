using DataCrunch.Acquire.Exceptions;
using System;

namespace DataCrunch.Acquire
{
    public class ArduinoSampleParser
    {
        public Sample Parse(string rawSample)
        {
            string[] pieces = rawSample.Split(' ');
            

            Sample sample = new Sample();

            try
            {
                const int DEFAULT_VALUE = -100000;
                int partIndex = 0;
                for (int i = 0; i < pieces.Length; i++)
                {
                    if (!string.IsNullOrEmpty(pieces[i]) && pieces[i] != "\r")
                    {
                        int value = DEFAULT_VALUE;
                        int.TryParse(pieces[i], out value);

                        if (value != DEFAULT_VALUE)
                        {
                            sample.parts[partIndex] = value;
                            partIndex++;
                        }
                    }
                }
            }
            catch (Exception e)
            {

                throw new InvalidFormatException(rawSample, e);
            }

            return sample;
        }
    }
}
