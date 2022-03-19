using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPrinciples
{
    public class CarGarage
    {
        private static CarGarage instance;

        private List<Car> carList;

        private CarGarage()
        {
            carList = new List<Car>();
        }

        public static CarGarage GetInstance() 
        {
            if (instance is null)
            {
                instance = new CarGarage();
            }

            return instance;
        }

        public void Add(Car car)
        {
            carList.Add(car);
        }

        public int GetTypesCount()
        {
            return carList.GroupBy(x => x.Brand).Count();
        }

        public int GetCarsCount()
        {
            return carList.Sum(x => x.Count);
        }

        public decimal GetAveragePrice()
        {
            return carList.Average(x => x.Price);
        }

        public decimal GetAveragePriceType(string brand)
        {
            return carList.Where(x => x.Brand == brand).Sum(t => t.Price)
                   / carList.Count(x => x.Brand == brand);
        }

        public void GetCarList()
        {
            foreach (var car in carList)
            {
                Console.WriteLine($"brand: {car.Brand} {Environment.NewLine} model: {car.Model} {Environment.NewLine} price: {car.Price} {Environment.NewLine} count: {car.Count}");
            }    

        }
    }
}
