using CarPark.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CarPark
{
    public class CarPark
    {
        public List<Vehicle> Vehicles { get; set; }

        public CarPark(List<Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (IsContains(vehicle))
            {
                throw new AddException();
            }

            Vehicles.Add(vehicle);
        }

        public List<Vehicle> GetAutoByParameter(string parameter, string value)
        {
            var t = parameter.Split(' ');
            var property = t[0];
            var propertyField = string.Empty;

            if (t.Count() > 1)
            {
                propertyField = t[1];
            }

            if (GetNumberOfAutoWithParameter(property) == 0)
            {
                throw new GetAutoByParameterException(parameter);
            }

            return Vehicles.Where(v => (string.IsNullOrEmpty(propertyField) ? GetValueByProperty(property, v) : GetValueByFieldInProperty(property, propertyField, v)).Equals(value)).ToList();
        }

        public void UpdateAuto(int id, Vehicle vehicle)
        {
            if (id < 0 || id >= Vehicles.Count)
            {
                throw new UpdateAutoException(id);
            }

            Vehicles[id] = vehicle;
        }

        public void RemoveAuto(int id, Vehicle vehicle)
        {
            if (id < 0 || id >= Vehicles.Count)
            {
                throw new RemoveAutoException(id);
            }

            Vehicles.RemoveAt(id);
        }

        private bool IsContains(Vehicle vehicle)
        {
            if (Vehicles.Contains(vehicle))
            {
                return true;
            }

            return false;
        }

        private PropertyInfo GetPropertyByName (string property, object obj)
        {
            return obj.GetType().GetProperty(property);
        }

        private string GetValueByProperty (string parameter, Vehicle vehicle)
        {
            PropertyInfo property = GetPropertyByName(parameter, vehicle);
            if (property is null)
            {
                return null;
            }

            return property.GetValue(vehicle).ToString();
        }

        private string GetValueByFieldInProperty (string parameter, string field, Vehicle vehicle)
        {
            PropertyInfo property = GetPropertyByName(parameter, vehicle);
            
            if (property is null)
            {
                return null;
            }

            var propertyValue = property.GetValue(vehicle);
            var propertyOfProperty = GetPropertyByName(field, propertyValue);

            return propertyOfProperty.GetValue(propertyValue).ToString();
        }

        private int GetNumberOfAutoWithParameter(string parameter)
        {
            return Vehicles.Select(v => GetPropertyByName(parameter, v)).Count(p => !(p is null));
        }
    }
}
