using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.AbstractFactory
{
    public abstract class ContinentFactory
    {
        public abstract Carnivore CreateCarnivore();
        public abstract Herbivore CreateHerbivore();
    }
}
