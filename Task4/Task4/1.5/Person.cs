namespace Task4._1._5;

public class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }

    public void Print()
    {
        Console.WriteLine(Name);
    }
}