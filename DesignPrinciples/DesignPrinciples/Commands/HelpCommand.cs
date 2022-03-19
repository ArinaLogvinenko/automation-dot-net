using System;
using System.Collections.Generic;

namespace DesignPrinciples.Commands
{
    public class HelpCommand : ICommand
    {
        readonly List<string> commands = new List<string>()
        {
            "help -- prints the help screen",
            "add -- addes car in cars list",
            "count types -- displays the number of car brands",
            "count all -- displays total number of cars",
            "average price -- displays average cost car",
            "average price type -- displays average cars cost of the specified brand",
            "list -- displays list of cars",
            "exit -- application shutdown"
        };

        public void Execute()
        {
            foreach (var command in commands)
            {
                Console.WriteLine(command);
            }
        }
    }
}
