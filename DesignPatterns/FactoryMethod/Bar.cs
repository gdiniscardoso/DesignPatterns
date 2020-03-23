using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.FactoryMethod
{
    public class Bar : Creator
    {
        public override IProduct CreateProduct()
        {
            return new Gin();
        }
    }
}
