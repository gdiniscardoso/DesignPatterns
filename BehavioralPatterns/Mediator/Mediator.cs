﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BehavioralPatterns.Mediator
{
    public interface IMediator
    {
        void Notify(object sender, string @event);
    }

    public class ConcreteMediator : IMediator
    {
        private Component1 _component1;
        private Component2 _component2;

        public ConcreteMediator(Component1 component1, Component2 component2)
        {
            _component1 = component1;
            _component1.SetMediator(this);
            _component2 = component2;
            _component2.SetMediator(this);
        }

        public void Notify(object sender, string @event)
        {
            if(@event == "A")
            {
                Console.WriteLine("Mediator reacts on A and triggers folowing operations:");
                _component2.DoC();
            }
            if (@event == "D")
            {
                Console.WriteLine("Mediator reacts on D and triggers following operations:");
                _component1.DoB();
                _component2.DoC();
            }
        }
    }

    public class BaseComponent
    {
        protected IMediator _mediator;

        public BaseComponent(IMediator mediator = null)
        {
            _mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
    }

    public class Component1 : BaseComponent
    {
        public void DoA()
        {
            Console.WriteLine("Component 1 does A.");

            this._mediator.Notify(this, "A");
        }

        public void DoB()
        {
            Console.WriteLine("Component 1 does B.");

            this._mediator.Notify(this, "B");
        }
    }

    public class Component2 : BaseComponent
    {
        public void DoC()
        {
            Console.WriteLine("Component 2 does C.");

            this._mediator.Notify(this, "C");
        }

        public void DoD()
        {
            Console.WriteLine("Component 2 does D.");

            this._mediator.Notify(this, "D");
        }
    }
}
