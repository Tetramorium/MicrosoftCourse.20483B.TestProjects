using System;
using System.Collections;

// Strategy Pattern
// https://www.codeproject.com/Articles/455228/Design-Patterns-of-Behavioral-Design-Patterns#Strategy

namespace Animal
{
    public abstract class Entity : IComparable<Entity>
    {
        public string Name { get; set; }
        public IGreetingBehaviour GreetingBehaviour;

        public Entity(string _Name, IGreetingBehaviour _GreetingBehaviour)
        {
            this.Name = _Name;
            this.GreetingBehaviour = _GreetingBehaviour;
        }

        public void IntroduceHumanSubject()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.Name, this.GreetingBehaviour.Greet()));
        }

        public int CompareTo(Entity other)
        {
            switch (other)
            {
                case Cat c:
                    if (c.GetType() == this.GetType())
                        return 0;
                    else
                    {
                        if (this is Dog)
                            return 1;
                        else
                            return -1;
                    }
                case Dog d:
                    if (d.GetType() == this.GetType())
                        return 0;
                    else
                    {
                        if (this is Cat)
                            return -1;
                        else
                            return 1;
                    }
                default:
                    return -1;
            }
        }
    }

    public interface IGreetingBehaviour
    {
        string Greet();
    }

    public class GreetIgnore : IGreetingBehaviour
    {
        public string Greet()
        {
            return "Ignoring you!";
        }
    }

    public class GreetWelcome : IGreetingBehaviour
    {
        public string Greet()
        {
            return "Jumping and barking!";
        }
    }

    public class GreetFlyAway : IGreetingBehaviour
    {
        public string Greet()
        {
            return "Fly away! Fly away!";
        }
    }

    public class Dog : Entity
    {
        public Dog(string _Name, IGreetingBehaviour _GreetingBehaviour) : base(_Name, _GreetingBehaviour)
        {
        }
    }

    public class Cat : Entity
    {
        public Cat(string _Name, IGreetingBehaviour _GreetingBehaviour) : base(_Name, _GreetingBehaviour)
        {
        }
    }

    public class Bird : Entity
    {
        public Bird(string _Name, IGreetingBehaviour _GreetingBehaviour) : base(_Name, _GreetingBehaviour)
        {
        }
    }
}