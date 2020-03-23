using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.FactoryMethod
{
    public class Client
    {
        public Client()
        {
        }

        public void DoRequest(Creator creator)
        {
            creator.DoStuff();
        }
    }
}
