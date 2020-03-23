using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.AbstractFactory
{
    public class LynxPardinus : Carnivore
    {
        public override void Eat(Herbivore herbivore)
        {
            Console.WriteLine($"{this.GetType().FullName} eats {herbivore.GetType().FullName}");
        }
    }
}
