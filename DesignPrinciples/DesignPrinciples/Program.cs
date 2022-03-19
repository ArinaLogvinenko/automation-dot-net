using System;

namespace DesignPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();
            CommandReader commandReader = new CommandReader();
            Console.WriteLine("print 'help' to see a list of commands");

            while (true)
            {
                ICommand command = commandReader.GetCommand(Console.ReadLine().Split(' '));
                invoker.ExecuteCommand(command);
            }
        }
    }
}
