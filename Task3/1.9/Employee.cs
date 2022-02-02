namespace Task3._1._9;

public class Employee : Person
{
    public void Display()
    {
        //Модификатор private
        // Console.WriteLine(_name);
        Console.WriteLine(Name);
    }

    public Employee()
    {
        
    }

    public Employee(string name) : base(name)
    {
        Console.WriteLine($"Вызов конструктора Employee с параметром name: {name}");
    }

    public Employee(string name, string lastName) : base(name, lastName)    
    {
        Console.WriteLine($"Вызов конструктора Employee с параметром name: {name}, lastname: {lastName}");
    }
}