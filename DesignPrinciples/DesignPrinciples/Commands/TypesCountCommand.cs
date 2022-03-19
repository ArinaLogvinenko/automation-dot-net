using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPrinciples.Commands
{
    public class TypesCountCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine(CarGarage.GetInstance().GetTypesCount());
        }
    }
}
