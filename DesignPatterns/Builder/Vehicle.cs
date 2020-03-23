using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.Builder
{
    public class Vehicle
    {
        private readonly string vehicleType;
        private readonly Dictionary<string, string> parts = new Dictionary<string, string>();

        public Vehicle(string vehicleType)
        {
            this.vehicleType = vehicleType;
        }

        public string this[string key]
        {
            get { return parts[key]; }
            set { parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine($"Vehicle Type: {vehicleType}");
            Console.WriteLine($" Frame : {parts["frame"]}");
            Console.WriteLine($" Engine : {parts["engine"]}");
            Console.WriteLine($" #Wheels: {parts["wheels"]}");
            Console.WriteLine($" #Doors : {parts["doors"]}");
        }
    }

    public enum VehicleTypeEnum
    {
        MotorCycle,
        Car,
        Scooter
    }
}
