using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.Builder
{
    public class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            vehicle = new Vehicle(VehicleTypeEnum.Scooter.ToString());
        }
        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "50 cc";
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "Scooter Frame";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }
    }
}
