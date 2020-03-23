using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.FactoryMethod
{
    public abstract class Creator
    {
        public abstract IProduct CreateProduct();

        public void DoStuff()
        {
            Console.WriteLine("Creating product...");
            IProduct obj = CreateProduct();
            Console.WriteLine("Doing product stuff...");
            obj.DoOperation();
            Console.WriteLine("Finished stuff...");
        }
    }
}
