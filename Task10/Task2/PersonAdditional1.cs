namespace Task10.Task2;

public partial class Person
{
    partial void Work();
    
    public void Run()
    {
        Console.WriteLine("I am running");
    }

    partial void Work()
    {
        Console.WriteLine("I am working");
    }
    
    public void DoWork()
    {
        Work();
    }
}