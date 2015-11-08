using System;

namespace DataCrunch.Acquire
{
    public class RowingSignal
    {
        public RowingPhases Phase { get; set; }
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Time elapsed (in milliseconds) from the last signal with the same phase time (Catch-Catch , Release-Release)
        /// </summary>
        public double StrokeTime { get; set; }

        public double SmoothedStrokeRate { get; set; }
    }

    public enum RowingPhases
    {
        Catch,
        Release
    }
}
