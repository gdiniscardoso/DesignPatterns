using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.AbstractFactory
{
    public abstract class Carnivore : Animal
    {
        public abstract void Eat(Herbivore herbivore);
    }
}
