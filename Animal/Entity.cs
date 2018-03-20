using System;

namespace Animal
{
    public abstract class Entity
    {
        public string Name { get; set; }
        private IGreetingBehaviour GreetingBehaviour;

        public Entity(string _Name, IGreetingBehaviour _GreetingBehaviour)
        {
            this.Name = _Name;
            this.GreetingBehaviour = _GreetingBehaviour;
        }

        public void IntroduceHumanSubject()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.Name, this.GreetingBehaviour.Greet()));
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
}
