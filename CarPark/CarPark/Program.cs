using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CarPark
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine K4M = new Engine { Power = 1600, Volume = 81, Type = Enums.EngineType.Benzin, SerialNumber = "DC3456G087" };
            Engine D2865 = new Engine { Power = 10000, Volume = 1.5f, Type = Enums.EngineType.Diesel, SerialNumber = "AANM13687" };
            Engine OM906LA = new Engine { Power = 6370, Volume = 1, Type = Enums.EngineType.Benzin, SerialNumber = "01HK1224300" };
            Engine QMB139 = new Engine { Power = 49, Volume = 4.5F, Type = Enums.EngineType.Diesel, SerialNumber = "JP15887" };

            Chassis carChassis = new Chassis { WheelCount = 4, Number = "7HN", PermissibleLoad = 500 };
            Chassis truckChassis = new Chassis { WheelCount = 8, Number = "66M", PermissibleLoad = 20000 };
            Chassis busChassis = new Chassis { WheelCount = 6, Number = "TGV12", PermissibleLoad = 11500 };
            Chassis scooterChassis = new Chassis { WheelCount = 2, Number = "139T", PermissibleLoad = 150 };

            Transmission carTransmission = new Transmission { Type = Enums.TransmissionType.Automatic, GearCount = 6, Manufacturer = "Renault" };
            Transmission truckTransmission = new Transmission { Type = Enums.TransmissionType.Mechanical, GearCount = 14, Manufacturer = "MAN" };
            Transmission busTransmission = new Transmission { Type = Enums.TransmissionType.Automatic, GearCount = 3, Manufacturer = "MAZ" };
            Transmission scooterTransmission = new Transmission { Type = Enums.TransmissionType.Mechanical, GearCount = 5, Manufacturer = "Nexus" };

            //List<Vehicle> list = new List<Vehicle>()
            //{
            //    new Car { Engine = K4M, Power = 200, Number = "A345h", Transmission = carTransmission, Model = "A2" },
            //    new Car { Engine = K4M, Power = 180, Number = "n877a", Transmission = carTransmission, Model = "Q7" },
            //    new Bus { Engine = QMB139, Power = 299, PeopleCapacity = 48, Transmission = busTransmission },
            //    new Bus { Engine = QMB139, Power = 350, PeopleCapacity = 90, Transmission = busTransmission },
            //    new Truck { Engine = OM906LA, Power = 500, LoadCapacity = 2000, Transmission = truckTransmission },
            //    new Truck {Engine = OM906LA, Power= 1500, LoadCapacity = 12000, Transmission = truckTransmission },
            //    new Scooter {Engine = D2865, Power = 100, Number = "ggs9", Transmission = scooterTransmission, Weight = 300 },
            //    new Scooter {Engine = D2865, Power = 133, Number = "ty12", Transmission = scooterTransmission, Weight = 255 }
            //};

            //// Полную информацию о всех транспортных средствах, обьем двигателя которых больше чем 1.5 литров
            //var bigEngineVolume = list.Where(x => x.Engine.Volume > 1.5).ToList();
            //CreateXML(bigEngineVolume, "EngineVolumeMore1.5");


            //// Тип двигателя, серийный номер и его мощность для всех автобусов и грузовиков
            //XDocument xdoc = new XDocument(new XElement("TruckAndBusEngines",
            //list.Where(x => x.GetType() == typeof(Truck) || x.GetType() == typeof(Bus))
            //.ToList().Select(t =>
            // new XElement("Transport", t.GetType().Name.ToString(),
            // new XElement("EngineType", t.Engine.Type),
            // new XElement("EnginePower", t.Engine.Power),
            // new XElement("SerialNumber", t.Engine.SerialNumber)))));
            //xdoc.Save("TnBEngines.xml");

            //// Полную информацию о всех транспортных средствах, сгруппированную по типу трансмиссии
            //var groupedTransport = list.GroupBy(x => x.Transmission.Type)
            //.Select(g => new HelpGroup() { GroupName = g.Key, Transports = g.ToList() })
            //.ToList();

            //CreateXML(groupedTransport, "GroupedTransport");

            // Exceptions
            try
            {
                //InitializationException
                //Car car = new Car(2000, "sfs2", "A2", carChassis, QMB139, carTransmission);

                Car car = new Car(200, "sfs2", "A2", carChassis, QMB139, carTransmission);
                Car car2 = new Car(400, "sfs3", "A2", carChassis, QMB139, carTransmission);
                Car car3 = new Car(500, "sfs4", "A2", carChassis, QMB139, carTransmission);


                List<Vehicle> park = new List<Vehicle>() { car, car2, car3 };

                CarPark carPark = new CarPark(park);

                //AddException
                //carPark.AddVehicle(car);

                //GetAutoByParameterException 
                //carPark.GetAutoByParameter("mark", "sfs4");

                //UpdateAutoException
                //carPark.UpdateAuto(3, car);

                //RemoveAutoException
                //carPark.RemoveAuto(3, car);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CreateXML(Object list, string name)
        {
            XmlSerializer formatter = new XmlSerializer(list.GetType());

            using (FileStream fs = new FileStream($"{name}.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, list);
            }
        }
    }
}
