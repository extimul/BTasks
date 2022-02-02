namespace Task1.Zadanie4and5;

public struct State
{
    public string Name;

    public Country Country;

    public override string ToString()
    {
        return $"Name: {Name}; Country: {Country?.Name}";
    }
}