namespace Task4._1._4;

public class Human
{
    public string Name { get; }

    public Human(string name)
    {
        Name = name;
    }

    public virtual void DisplayName()
    {
        Console.WriteLine(Name);
    }
}