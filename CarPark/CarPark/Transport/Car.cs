using CarPark.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarPark
{
    public class Car : Vehicle
    {
        public float Power { get; set; }

        public string Number { get; set; }

        public string Model { get; set; }

        public Car() { }

        public Car(float power, string number, string model, Chassis chassis, Engine engine, Transmission transmission)
               : base(chassis, engine, transmission)
        {
            this.Power = power;
            this.Number = number;
            this.Model = model;

            if (!IsValidCar())
            {
                throw new InitializationException();
            }
        }

        private bool IsValidCar()
        {
            return this.Power <= 1360 && this.Power >= 5;
        }
    }
}
