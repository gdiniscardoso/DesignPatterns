using CreationalPatterns.AbstractFactory;
using CreationalPatterns.Builder;
using CreationalPatterns.FactoryMethod;
using CreationalPatterns.Prototype;
using System;
using System.Collections.Generic;

namespace DesignPatternsApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "-abstractfactory":
                        DoAbstractFactory();
                        break;
                    case "-builder":
                        DoBuilder();
                        break;
                    case "-factoryMethod":
                        DoFactoryMethod();
                        break;
                    case "-proptotype":
                        DoPrototype();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void DoPrototype()
        {
            Person person = new Person(30, "GD", new Identification(1));
            Person clone1 = person.ShallowClone();
            Person clone2 = person.DeepClone();

            Console.WriteLine(person.ToString());
            Console.WriteLine(clone1.ToString());
            Console.WriteLine(clone2.ToString());

            person.Age = 29;
            person.Name = "XM";
            person.Identification.Id = 2;

            Console.WriteLine(person.ToString());
            Console.WriteLine(clone1.ToString());
            Console.WriteLine(clone2.ToString());
        }

        private static void DoAbstractFactory()
        {
            AnimalWorld animalWorld = new AnimalWorld(new EuropaContinent());
            animalWorld.ExecuteFoodChain();
            Console.ReadKey();
        }

        private static void DoBuilder()
        {
            Shop shop = new Shop();

            List<VehicleBuilder> builders = new List<VehicleBuilder>
            {
                new CarBuilder(),
                new MotorCycleBuilder(),
                new ScooterBuilder()
            };

            foreach (var builder in builders)
            {
                shop.Construct(builder);
                builder.Vehicle.Show();
            }
        }

        private static void DoFactoryMethod()
        {
            Client client = new Client();
            client.DoRequest(new Bar());
            client.DoRequest(new Caffeteria());
        }
    }
}
