using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructuralPatterns.Flyweight
{
    public class Car
    {
        public string Owner { get; set; }
        public string Number { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    }

    public class Flyweight
    {
        private Car _sharedState;

        public Flyweight(Car car)
        {
            _sharedState = car;
        }

        public void Operation(Car uniqueState)
        {
            string s = JsonConvert.SerializeObject(this._sharedState);
            string u = JsonConvert.SerializeObject(uniqueState);
            Console.WriteLine($"Flyweight: Displaying shared {s} and unique {u} state.");
        }
    }

    public class FlyweightFactory
    {
        private List<Tuple<Flyweight, string>> flyweights = new List<Tuple<Flyweight, string>>();

        public FlyweightFactory(params Car[] cars)
        {
            foreach(var item in cars)
            {
                flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(item), this.GetKey(item)));
            }
        }

        private string GetKey(Car item)
        {
            List<string> elements = new List<string>()
            {
                item.Model,
                item.Color,
                item.Company,
            };

            if(item.Owner != null && item.Number != null)
            {
                elements.Add(item.Number);
                elements.Add(item.Owner);
            }

            return string.Join(" ", elements);
        }

        public Flyweight GetFlyWeight(Car sharedState)
        {
            string key = this.GetKey(sharedState);

            if(flyweights.Where(x => x.Item2 == key).Count() == 0)
            {
                Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
                this.flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), key));
            }
            else
            {
                Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
            }

            return this.flyweights.Where(x => x.Item2 == key).FirstOrDefault().Item1;
        }

        public void ListFlyWeights()
        {
            var count = flyweights.Count;
            Console.WriteLine($"\nFlyweightFactory: I have {count} flyweights:");
            foreach (var flyweight in flyweights)
            {
                Console.WriteLine(flyweight.Item2);
            }
        }
    }
}
