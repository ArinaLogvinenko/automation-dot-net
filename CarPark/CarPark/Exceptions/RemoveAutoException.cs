using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Exceptions
{
    public class RemoveAutoException : Exception
    {
        public RemoveAutoException(int id) : base($"Unable remove auto {id}") { }
    }
}
