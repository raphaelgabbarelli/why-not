using System;

namespace DataCrunch.Acquire
{
    public class Sample
    {
        public int[] parts = new int[6];

        public Sample()
        {
            for(int i=0; i<parts.Length; i++)
            {
                parts[i] = 0;
            }
        }

        public int x { get { return parts[0]; } }
        public int y { get { return parts[1]; } }
        public int z { get { return parts[2]; } }
        public int a { get { return parts[3]; } }
        public int b { get { return parts[4]; } }
        public int c { get { return parts[5]; } }

        public static Sample operator +(Sample a, Sample b)
        {
            Sample result = new Sample();

            for(int i = 0; i < a.parts.Length; i++)
            {
                result.parts[i] = a.parts[i] + b.parts[i];
            }

            return result;
        }

        public static Sample operator -(Sample a, Sample b)
        {
            Sample result = new Sample();
            
            for (int i = 0; i < a.parts.Length; i++)
            {
                var difference = a.parts[i] - b.parts[i];
                if(Math.Abs(a.parts[i] - b.parts[i]) > 100)
                {
                    result.parts[i] = a.parts[i] - b.parts[i];
                }
            }

            return result;
        }
    }
}
