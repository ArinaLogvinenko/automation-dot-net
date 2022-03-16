using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Exceptions
{
    public class UpdateAutoException : Exception
    {
        public UpdateAutoException(int id) : base($"Unable update auto {id}") { }
    }
}
