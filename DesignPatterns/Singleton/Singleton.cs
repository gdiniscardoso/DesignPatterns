using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns.Singleton
{
    public class Singleton
    {
        private static Singleton _instance;

        private Singleton() { }

        public static Singleton GetInstance()
        {
            if(_instance is null)
            {
                _instance = new Singleton();
            }

            return _instance;
        }
    }
}
