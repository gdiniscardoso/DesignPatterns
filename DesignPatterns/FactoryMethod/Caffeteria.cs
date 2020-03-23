using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.FactoryMethod
{
    public class Caffeteria : Creator
    {
        public override IProduct CreateProduct()
        {
            return new Coffee();
        }
    }
}
