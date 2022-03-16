using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Exceptions
{
    public class GetAutoByParameterException : Exception
    {
        public GetAutoByParameterException(string parameter) : base($"Unable to get auto by {parameter}") { }
    }
}
