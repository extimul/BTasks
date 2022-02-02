namespace Task3._1._12;

public class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
    public void Display()
    {
        Console.WriteLine($"Person {Name}");
        var a = new A();
        var b = new B();
        var t = b as A;
    }
}

public class A
{
    
}

public class B : A
{
    
}
