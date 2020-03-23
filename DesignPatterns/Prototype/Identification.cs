using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.Prototype
{
    public class Identification : ICloneable
    {
        public int Id;
        public Identification(int id)
        {
            Id = id;
        }

        public object Clone()
        {
            return new Identification(Id);
        }
    }
}
