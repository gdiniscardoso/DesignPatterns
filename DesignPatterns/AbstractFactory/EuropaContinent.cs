using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.AbstractFactory
{
    public class EuropaContinent : ContinentFactory
    {
        public override Carnivore CreateCarnivore()
        {
            return new LynxPardinus();
        }

        public override Herbivore CreateHerbivore()
        {
            return new Rabbit();
        }
    }
}
