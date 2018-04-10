using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animal;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int b = 2;
            string str = "abc";

            Print(b, nameof(b));
            Print(str, nameof(str));

            b = b << 1;

            Print(b, nameof(b));

            Dog d = new Dog("Bob", new GreetWelcome());
            Print(d, nameof(d));
            d.IntroduceHumanSubject();

            Cat c = new Cat("Milou", new GreetIgnore());
            c.IntroduceHumanSubject();
            Print(c, nameof(c));

            Entity e = c as Entity;
            Print(e, nameof(e));

            e.IntroduceHumanSubject();

            // Changing behaviour

            Console.WriteLine("Changing behaviour!");

            e.GreetingBehaviour = new GreetWelcome();

            e.IntroduceHumanSubject();

            feed(e);

            feed(d);

            List<Entity> entities = new List<Entity>();

            Cat c1 = new Cat("c1 Milou", new GreetIgnore());
            Cat c2 = new Cat("c2 Sam", new GreetIgnore());
            Cat c3 = new Cat("c3 Bram", new GreetIgnore());
            Cat c4 = new Cat("c4 Milou", new GreetIgnore());

            Dog d1 = new Dog("d1 Bob", new GreetWelcome());
            Dog d2 = new Dog("d2 Max", new GreetWelcome());
            Dog d3 = new Dog("d3 Boris", new GreetWelcome());
            Dog d4 = new Dog("d4 Rex", new GreetWelcome());

            Bird b1 = new Bird("b1 Twitter", new GreetFlyAway());
            Bird b2 = new Bird("b2 Birb", new GreetFlyAway());
            Bird b3 = new Bird("b3 Genji", new GreetFlyAway());
            Bird b4 = new Bird("b4 Birdperson", new GreetFlyAway());

            entities.Add(b1);

            entities.Add(c1);
            entities.Add(d1);

            entities.Add(b4);

            entities.Add(c2);
            entities.Add(d2);

            entities.Add(b2);

            entities.Add(d3);
            entities.Add(d4);

            entities.Add(b3);

            entities.Add(c3);
            entities.Add(c4);

            foreach(Entity animal in entities)
            {
                Console.WriteLine(animal.Name);
            }

            entities.Sort();

            PrintLine();

            foreach (Entity animal in entities)
            {
                Console.WriteLine(animal.Name);
            }
        }

        static void Print<T>(T _Obj, string _Identifier)
        {
            Console.WriteLine(_Obj.GetType() + " : " + _Identifier + " : " + _Obj.ToString());

            PrintLine();
        }

        static void PrintLine()
        {
            Console.WriteLine("\n----------------------\n");
        }

        static void feed(Entity t)
        {
            switch (t.GetType())
            {
                case Type DogType when DogType == typeof(Dog):
                    Console.WriteLine("Give a bone");
                    PrintLine();
                    break;
                case Type CatType when CatType == typeof(Cat):
                    Console.WriteLine("Give a fish");
                    PrintLine();
                    break;
            }
        }
    }
}
