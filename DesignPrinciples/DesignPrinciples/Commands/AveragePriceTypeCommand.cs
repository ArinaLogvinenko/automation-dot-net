using System;

namespace DesignPrinciples.Commands
{
    public class AveragePriceTypeCommand : ICommand
    {
        private string Brand;

        public AveragePriceTypeCommand(string brand)
        {
            this.Brand = brand;
        }

        public void Execute()
        {
            Console.WriteLine(CarGarage.GetInstance().GetAveragePriceType(Brand));
        }
    }
}
