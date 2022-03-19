using System;

namespace DesignPrinciples.Commands
{
    public class AveragePriceCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine(CarGarage.GetInstance().GetAveragePrice());
        }
    }
}
