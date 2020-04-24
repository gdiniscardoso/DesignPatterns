using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns.Adapter
{
    public interface IRequest
    {
        string GetRequest();
    }

    public class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific Request";
        }
    }

    public class Adapter : IRequest
    {
        private readonly Adaptee _adaptee;
        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public string GetRequest()
        {
            return _adaptee.GetSpecificRequest();
        }
    }
}
