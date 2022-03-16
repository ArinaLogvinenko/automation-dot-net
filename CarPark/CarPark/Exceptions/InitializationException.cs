using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Exceptions
{
    public class InitializationException : Exception
    {
        public InitializationException() : base("Unable to initilize") { }
    }
}
