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
            e.IntroduceHumanSubject();
            Print(e, nameof(e));

            feed(e);

            feed(d);
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
