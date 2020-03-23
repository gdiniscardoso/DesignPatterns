using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.FactoryMethod
{
    public class Coffee : IProduct
    {
        public void DoOperation()
        {
            Console.WriteLine("Preparing coffee");
        }
    }
}
