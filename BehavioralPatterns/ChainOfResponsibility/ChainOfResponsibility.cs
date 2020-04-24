using System;
using System.Collections.Generic;
using System.Text;

namespace BehavioralPatterns.ChainOfResponsibility
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        object Handle(object request);
    }

    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public virtual object Handle(object request)
        {
            if(_nextHandler != null)
            {
                return _nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        
    }

    public class MonkeyHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request is string && request.ToString() == "Banana")
            {
                return $"Monkey: I'll eat the {request.ToString()}.\n";
            }
            return base.Handle(request);
        }
    }

    public class SquirellHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request is string && request.ToString() == "Nut")
            {
                return $"Squirell: I'll eat the {request.ToString()}.\n";
            }
            return base.Handle(request);
        }
    }

    public class DogHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request is string && request.ToString() == "MeatBall")
            {
                return $"Dog: I'll eat the {request.ToString()}.\n";
            }
            return base.Handle(request);
        }
    }

    public class Client
    {
        public static void ClientCode(AbstractHandler handler)
        {
            foreach (var food in new List<string>() { "Nut", "Banana", "Cup of coffee" })
            {
                Console.WriteLine($"Client: who wants a {food}?");

                var result = handler.Handle(food);

                if (result != null)
                {
                    Console.WriteLine($"    {result}");
                }
                else
                {
                    Console.WriteLine($"    {food} was left untouched");
                }
            }
        }
    }
}
