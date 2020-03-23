using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.Builder
{
    public class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder()
        {
            vehicle = new Vehicle(VehicleTypeEnum.MotorCycle.ToString());
        }

        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }

        public override void BuildEngine()
        {
            vehicle["engine"] = "500 cc";
        }

        public override void BuildFrame()
        {
            vehicle["frame"] = "MotorCycle Frame";
        }

        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }
    }
}
