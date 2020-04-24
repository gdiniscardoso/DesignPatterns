using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns.Facade
{
    public class SubSystem1
    {
        public string Operation1()
        {
            return "Subsystem1 Ready!";
        }

        public string OperationA()
        {
            return "Subsystem1 Go!";
        }
    }
    public class SubSystem2
    {
        public string Operation2()
        {
            return "Subsystem2 Scheduled!";
        }

        public string OperationB()
        {
            return "Subsystem2 Finished!";
        }
    }

    public class Facade
    {
        protected SubSystem1 _subsystem1;
        protected SubSystem2 _subsystem2;

        public Facade(SubSystem1 subSystem1, SubSystem2 subSystem2)
        {
            _subsystem1 = subSystem1;
            _subsystem2 = subSystem2;
        }

        public string Operation()
        {
            string result = "Facade initializes subsystems:\n";
            result += this._subsystem1.Operation1();
            result += this._subsystem2.Operation2();
            result += "Facade orders subsystems to perform the action:\n";
            result += this._subsystem1.OperationA();
            result += this._subsystem2.OperationB();
            return result;
        }

        public class Client
        {
            public static void ClientCode(Facade facade)
            {
                Console.WriteLine(facade.Operation());
            }
        }
    }
}
