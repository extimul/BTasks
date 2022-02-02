namespace Task4._1._5;

public class Employee : Person
{
    public string Company { get; }
    // public new string Name { get; set; }

    public Employee(string name, string company) : base(name)
    {
        Company = company;
    }

    public new void Print()
    {
        Console.WriteLine($"{Name} работает в {Company}");
    }
}