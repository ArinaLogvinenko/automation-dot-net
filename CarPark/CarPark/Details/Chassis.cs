using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark
{
    public class Chassis
    {
        public int WheelCount { get; set; }

        public string Number { get; set; }

        public int PermissibleLoad { get; set; }

        public void Print()
        {
            Console.WriteLine($"Шасси. {Environment.NewLine} количество колес: {this.WheelCount} номер: {this.Number} допустимая нагрузка: {this.PermissibleLoad}");
        }
    }
}
