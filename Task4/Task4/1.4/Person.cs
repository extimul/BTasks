namespace Task4._1._4;

public class Person : Human
{
    public Person(string name) : base(name)
    {
    }

    public sealed override void DisplayName()
    {
        Console.WriteLine($"My name is {Name}");
    }
}