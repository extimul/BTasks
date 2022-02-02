namespace Task2._1._3;

public class Person
{
    private string name;

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Name2
    {
        get => name;
        private set => name = value;
    }
    
    public string Name3 { get; set; }
}