using CarPark.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark
{
    [Serializable]
    public class Transmission
    {
        public TransmissionType Type { get; set; }

        public int GearCount { get; set; }

        public string Manufacturer { get; set; }

        public void Print()
        {
            Console.WriteLine($"Трансмиссия. {Environment.NewLine} тип: {this.Type} количество передач: {this.GearCount} производитель: {this.Manufacturer}");
        }
    }
}
