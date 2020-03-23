using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.AbstractFactory
{
    public abstract class Animal
    {
        public Animal()
        {
            Console.WriteLine(this.GetType().FullName);
        }
    }
}
