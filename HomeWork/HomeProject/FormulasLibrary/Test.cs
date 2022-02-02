namespace FormulasLibrary;

public class Test
{
    public void PublicMethod()
    {
        Console.WriteLine("Public");
    }

    private void PrivateMethod()
    {
        Console.WriteLine("Private");
    }

    private protected void PrivateProtectedMethod()
    {
        Console.WriteLine("Private protected");
    }

    protected void ProtectedMethod()
    {
        Console.WriteLine("Protected");
    }

    internal void InternalMethod()
    {
        Console.WriteLine("Internal");
    }

    protected internal void ProtectedInternalMethod()
    {
        Console.WriteLine("Protected Internal");
    }
}