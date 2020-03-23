using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.FactoryMethod
{
    public class Gin : IProduct
    {
        public void DoOperation()
        {
            Console.WriteLine("Mixing flavors and putting some ice...");
        }
    }
}
