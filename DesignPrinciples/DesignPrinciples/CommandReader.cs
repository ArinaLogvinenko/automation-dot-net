using System;
using DesignPrinciples.Commands;

namespace DesignPrinciples
{
    public class CommandReader
    {
        public ICommand GetCommand(string[] commands)
        {
            ICommand command;

            switch (commands[0])
            {
                case "add":
                    command = GetAddCommand();
                    break;

                case "count":
                    command = GetCountCommand(commands);
                    break;

                case "average":
                    command = GetAverageCommand(commands);
                    break;

                case "help":
                    command = new HelpCommand();
                    break;

                case "list":
                    command = new ListCommand();
                    break;

                case "exit":
                    command = new ExitCommand();
                    break;

                default:
                    command = null;
                    break;
            }

            if (command == null)
            {
                Console.WriteLine("No command");
            }

            return command;
        }

        private ICommand GetAddCommand() 
        {
            Console.Write("Car brand: ");
            string brand = Console.ReadLine();

            Console.Write("Car model: ");
            string model = Console.ReadLine();

            Console.Write("Car price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Car count: ");
            int count = Convert.ToInt32(Console.ReadLine());

            Car car = new Car(brand, model, price, count);
            return new AddCommand(car);
        }

        private ICommand GetCountCommand(string[] args)
        {
            if (args.Length != 2)
            {
                throw new ArgumentException($"Need to enter 2 arguments");
            }

            switch (args[1])
            {
                case "types":
                    return new TypesCountCommand();
                case "all":
                    return new CarsCountCommand();
                default:
                    return null;
            }
        }

        private ICommand GetAverageCommand(string[] args)
        {
            if (args.Length > 3 && args.Length < 2)
            {
                throw new ArgumentException($"Wrong arguments count");
            }

            switch (args[1])
            {
                case "price":
                    return GetAveragePriceCommand(args);
                default:
                    return null;
            }
        }

        private ICommand GetAveragePriceCommand(string[] args)
        {
            switch (args.Length)
            {
                case 2:
                    return new AveragePriceCommand();
                case 3:
                    return new AveragePriceTypeCommand(args[2]);
                default:
                    return null;
            }
        }
    }
}
