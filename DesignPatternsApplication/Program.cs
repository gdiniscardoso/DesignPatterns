using BehavioralPatterns.ChainOfResponsibility;
using BehavioralPatterns.Command;
using BehavioralPatterns.Iterator;
using BehavioralPatterns.Mediator;
using BehavioralPatterns.Memento;
using BehavioralPatterns.Observer;
using BehavioralPatterns.State;
using BehavioralPatterns.Strategy;
using BehavioralPatterns.Visitor;
using CreationalPatterns.AbstractFactory;
using CreationalPatterns.Builder;
using CreationalPatterns.FactoryMethod;
using CreationalPatterns.Prototype;
using CreationalPatterns.Singleton;
using StructuralPatterns.Adapter;
using StructuralPatterns.Bridge;
using StructuralPatterns.Composite;
using StructuralPatterns.Decorator;
using StructuralPatterns.Flyweight;
using System;
using System.Collections.Generic;
using static BehavioralPatterns.ChainOfResponsibility.AbstractHandler;

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
                    case "-singleton":
                        DoSingleton();
                        break;
                    case "-adapter":
                        DoAdapter();
                        break;
                    case "-bridge":
                        DoBridge();
                        break;
                    case "-composite":
                        DoComposite();
                        break;
                    case "-decorator":
                        DoDecorator();
                        break;
                    case "-facade":
                        DoFacade();
                        break;
                    case "-flyweight":
                        DoFlyweight();
                        break;
                    case "-proxy":
                        DoProxy();
                        break;
                    case "-cor":
                        DoChainOfResponsibility();
                        break;
                    case "-command":
                        DoCommand();
                        break;
                    case "-iterator":
                        DoIterator();
                        break;
                    case "-mediator":
                        DoMediator();
                        break;
                    case "-memento":
                        DoMemento();
                        break;
                    case "-observer":
                        DoObserver();
                        break;
                    case "-state":
                        DoState();
                        break;
                    case "-strategy":
                        DoStrategy();
                        break;
                    case "-templatemethod":
                        DoTemplateMethod();
                        break;
                    case "-visitor":
                        DoVisitor();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void DoVisitor()
        {
            List<IComponent> components = new List<IComponent>
            {
                new ConcreteComponentA(),
                new ConcreteComponentB()
            };

            Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
            var visitor1 = new ConcreteVisitor1();
            BehavioralPatterns.Visitor.Client.ClientCode(components, visitor1);

            Console.WriteLine();

            Console.WriteLine("It allows the same client code to work with different types of visitors:");
            var visitor2 = new ConcreteVisitor2();
            BehavioralPatterns.Visitor.Client.ClientCode(components, visitor2);
        }

        private static void DoTemplateMethod()
        {
            Console.WriteLine("Same client code can work with different subclasses:");

            BehavioralPatterns.TemplateMethod.Client.ClientCode(new BehavioralPatterns.TemplateMethod.ConcreteClassA());

            Console.Write("\n");

            Console.WriteLine("Same client code can work with different subclasses:");
            BehavioralPatterns.TemplateMethod.Client.ClientCode(new BehavioralPatterns.TemplateMethod.ConcreteClassB());
        }

        private static void DoStrategy()
        {
            // The client code picks a concrete strategy and passes it to the
            // context. The client should be aware of the differences between
            // strategies in order to make the right choice.
            var context = new BehavioralPatterns.Strategy.Context();

            Console.WriteLine("Client: Strategy is set to normal sorting.");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomeBusinessLogic();
        }

        private static void DoState()
        {
            var context = new BehavioralPatterns.State.Context(new ConcreteStateA());
            context.Request1();
            context.Request2();
        }

        private static void DoObserver()
        {
            // The client code.
            var subject = new Subject();
            var observerA = new ConcreteObserverA();
            subject.Attach(observerA);

            var observerB = new ConcreteObserverB();
            subject.Attach(observerB);

            subject.SomeBusinessLogic();
            subject.SomeBusinessLogic();

            subject.Dettach(observerB);

            subject.SomeBusinessLogic();
        }

        private static void DoMemento()
        {
            // Client code.
            Originator originator = new Originator("Super-duper-super-puper-super.");
            Caretaker caretaker = new Caretaker(originator);

            caretaker.Backup();
            originator.DoSomething();

            caretaker.Backup();
            originator.DoSomething();

            caretaker.Backup();
            originator.DoSomething();

            Console.WriteLine();
            caretaker.ShowHistory();

            Console.WriteLine("\nClient: Now, let's rollback!\n");
            caretaker.Undo();

            Console.WriteLine("\n\nClient: Once more!\n");
            caretaker.Undo();

            Console.WriteLine();
        }

        private static void DoMediator()
        {
            Component1 component1 = new Component1();
            Component2 component2 = new Component2();
            new ConcreteMediator(component1, component2);

            Console.WriteLine("Client triggets operation A.");
            component1.DoA();

            Console.WriteLine();

            Console.WriteLine("Client triggers operation D.");
            component2.DoD();
        }

        private static void DoIterator()
        {
            // The client code may or may not know about the Concrete Iterator
            // or Collection classes, depending on the level of indirection you
            // want to keep in your program.
            var collection = new WordsCollection();
            collection.AddItem("First");
            collection.AddItem("Second");
            collection.AddItem("Third");

            Console.WriteLine("Straight traversal:");

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("\nReverse traversal:");

            collection.ReverseDirection();

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }
        }

        private static void DoCommand()
        {
            // The client code can parameterize an invoker with any commands.
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("Say Hi!"));
            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));

            invoker.DoSomethingImportant();
        }

        private static void DoChainOfResponsibility()
        {
            var monkey = new MonkeyHandler();
            var squirell = new SquirellHandler();
            var dog = new DogHandler();

            monkey.SetNext(squirell).SetNext(dog);

            Console.WriteLine("Chain: Monkey > Squirell > Dog\n");
            BehavioralPatterns.ChainOfResponsibility.Client.ClientCode(monkey);
            Console.WriteLine(squirell);
        }

        private static void DoProxy()
        {
            throw new NotImplementedException();
        }

        private static void DoFlyweight()
        {
            var factory = new FlyweightFactory
            (
                new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
                new Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
                new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
                new Car { Company = "BMW", Model = "M5", Color = "red" },
                new Car { Company = "BMW", Model = "X6", Color = "white" }
            );
            factory.ListFlyWeights();

            Console.WriteLine("\nClient: Adding a car to database.");

            var car = new Car
            {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "M5",
                Color = "red"
            };
            var flyweight = factory.GetFlyWeight(new Car
            {
                Color = car.Color,
                Model = car.Model,
                Company = car.Company
            });

            // The client code either stores or calculates extrinsic state and
            // passes it to the flyweight's methods.
            flyweight.Operation(car);

            car = new Car
            {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "X1",
                Color = "red"
            };
            flyweight = factory.GetFlyWeight(new Car
            {
                Color = car.Color,
                Model = car.Model,
                Company = car.Company
            });

            // The client code either stores or calculates extrinsic state and
            // passes it to the flyweight's methods.
            flyweight.Operation(car);


            factory.ListFlyWeights();
        }

        private static void DoFacade()
        {
            StructuralPatterns.Facade.Facade.Client.ClientCode(new StructuralPatterns.Facade.Facade(new StructuralPatterns.Facade.SubSystem1(), new StructuralPatterns.Facade.SubSystem2()));
        }

        private static void DoDecorator()
        {
            DecoratorClient client = new DecoratorClient();

            ConcreteComponent simple = new ConcreteComponent();
            Console.WriteLine("Client: I get a simple component:");
            client.ClientCode(simple);
            Console.WriteLine();

            ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
            Console.WriteLine("Client: Now I've got decorated component");
            client.ClientCode(decorator2);
        }

        private static void DoComposite()
        {
            StructuralPatterns.Composite.Client client = new StructuralPatterns.Composite.Client();

            // This way the client code can support the simple leaf
            // components...
            Leaf leaf = new Leaf();
            Console.WriteLine("Client: I get a simple component:");
            client.ClientCode(leaf);

            // ...as well as the complex composites.
            Composite tree = new Composite();
            Composite branch1 = new Composite();
            branch1.Add(new Leaf());
            branch1.Add(new Leaf());
            Composite branch2 = new Composite();
            branch2.Add(new Leaf());
            tree.Add(branch1);
            tree.Add(branch2);
            Console.WriteLine("Client: Now I've got a composite tree:");
            client.ClientCode(tree);

            Console.Write("Client: I don't need to check the components classes even when managing the tree:\n");
            client.ClientCode2(tree, leaf);
        }

        private static void DoBridge()
        {
            Remote remote;

            remote = new Remote(new Television());
            Console.WriteLine(remote.GetDeviceName());

            remote = new AdvancedRemote(new Radio());
            Console.WriteLine(remote.GetDeviceName());
        }

        private static void DoAdapter()
        {
            IRequest request = new Adapter(new Adaptee());
            Console.WriteLine(request.GetRequest());
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
            CreationalPatterns.FactoryMethod.Client client = new CreationalPatterns.FactoryMethod.Client();
            client.DoRequest(new Bar());
            client.DoRequest(new Caffeteria());
        }

        private static void DoSingleton()
        {
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            }
            else
            {
                Console.WriteLine("Singleton failed, variables contain different instances.");
            }
        }
    }
}
