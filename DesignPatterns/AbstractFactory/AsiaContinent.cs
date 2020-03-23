using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.AbstractFactory
{
    public class AsiaContinent : ContinentFactory
    {
        public override Carnivore CreateCarnivore()
        {
            throw new NotImplementedException();
        }

        public override Herbivore CreateHerbivore()
        {
            throw new NotImplementedException();
        }
    }
}
