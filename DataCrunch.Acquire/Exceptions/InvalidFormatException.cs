using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCrunch.Acquire.Exceptions
{
    public class InvalidFormatException : Exception
    {
        public InvalidFormatException(string sample)
            : base("Invalid sample: " + sample)
        { }

        public InvalidFormatException(string sample, Exception innerException)
            : base("Invalid sample: " + sample, innerException)
        { }
    }
}
