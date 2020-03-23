using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.AbstractFactory
{
    public class Wolf : Carnivore
    {
        public override void Eat(Herbivore herbivore)
        {
            Console.WriteLine($"{this.GetType().FullName} and his pack eat {herbivore.GetType().FullName}");
        }
    }
}
