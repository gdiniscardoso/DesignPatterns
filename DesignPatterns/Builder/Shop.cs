using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.Builder
{
    public class Shop
    {
        public void Construct(VehicleBuilder builder)
        {
            builder.BuildFrame();
            builder.BuildEngine();
            builder.BuildDoors();
            builder.BuildWheels();
        }
    }
}
