using System;

namespace DesignPrinciples.Commands
{
    public class AddCommand : ICommand
    {
        private Car car;

        public AddCommand(Car car)
        {
            this.car = car;
        }

        public void Execute() 
        {
            CarGarage.GetInstance().Add(car);
            Console.WriteLine("Car is added");
        }
    }
}
