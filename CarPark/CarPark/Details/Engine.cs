using CarPark.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark
{
    public class Engine
    {
        public int Power { get; set; }

        public float Volume { get; set; }

        public EngineType Type { get; set; }

        public string SerialNumber { get; set; }

        public void Print()
        {
            Console.WriteLine($"Двигатель. {Environment.NewLine} мощность: {this.Power} объем: {this.Volume} тип: {this.Type} серийный номер: {this.SerialNumber}");
        }
    }
}
