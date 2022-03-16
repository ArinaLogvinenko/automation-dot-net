using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Exceptions
{
    public class AddException : Exception
    {
        public AddException() : base("Unable to add auto") { }
    }
}
