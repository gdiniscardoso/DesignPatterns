using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.Prototype
{
    public class Person
    {
        public int Age;
        public string Name;
        public Identification Identification;

        public Person()
        {

        }

        public Person(int age, string name, Identification identification)
        {
            Age = age;
            Name = name;
            Identification = identification;
        }

        public Person ShallowClone()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepClone()
        {
            Person person = (Person)this.MemberwiseClone();
            person.Identification = new Identification(person.Identification.Id);
            person.Name = string.Copy(Name);
            return person;
        }

        public override string ToString()
        {
            return $"{this.Age}\n{Name}\n{Identification.Id}";
        }
    }
}
