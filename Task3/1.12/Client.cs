namespace Task3._1._12;

public class Client : Person
{
    public string Bank { get; set; }
    
    public Client(string name, string bank) : base(name)
    {
        Bank = bank;
    }

}