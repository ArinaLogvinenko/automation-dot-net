using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarPark
{
    [XmlInclude(typeof(Car)), XmlInclude(typeof(Bus)),
        XmlInclude(typeof(Scooter)), XmlInclude(typeof(Truck))]
    public abstract class Vehicle
    {
        public Engine Engine { get; set; }

        public Transmission Transmission { get; set; }

        public Chassis Chassis { get; set; }

        protected Vehicle() { }

        protected Vehicle(Chassis chassis, Engine engine, Transmission transmission)
        {
            this.Chassis = chassis;
            this.Engine = engine;
            this.Transmission = transmission;
        }

        public void Print()
        {
            Engine.Print();
            Transmission.Print();
            Chassis.Print();
        }
    }
}
