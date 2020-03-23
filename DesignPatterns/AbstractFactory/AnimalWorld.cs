using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.AbstractFactory
{
    public class AnimalWorld
    {
        readonly Herbivore herbivore;
        readonly Carnivore carnivore;

        public AnimalWorld(ContinentFactory factory)
        {
            herbivore = factory.CreateHerbivore();
            carnivore = factory.CreateCarnivore();
        }

        public void ExecuteFoodChain()
        {
            carnivore.Eat(herbivore);
        }
    }
}
