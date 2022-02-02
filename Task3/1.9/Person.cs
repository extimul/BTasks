namespace Task3._1._9;

public class Person
{
    private string _name;

    private string _lastName;
 
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string LastName
    {
        get => _lastName;
        set => _lastName = value;
    }

    public Person()
    {
        LastName = "78";
    }

    public Person(string name)
    {
        Console.WriteLine($"Вызов конструктора Person с параметром name: {name}");
        _name = name;
    }
    
    public Person(string name, string lastName) : this(name)
    {
        Console.WriteLine($"Вызов конструктора Person с параметром name: {name}, lastname: {lastName}");
        _lastName = lastName;
    }
    
    public void Display()
    {
        Console.WriteLine(Name);
        Console.WriteLine(LastName);
    }

}