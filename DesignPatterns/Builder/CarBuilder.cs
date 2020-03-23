using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.Builder
{
    public class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            vehicle = new Vehicle(VehicleTypeEnum.Car.ToString());
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "4";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "2500 cc";
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "Car Frame";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "4";
        }
    }
}
