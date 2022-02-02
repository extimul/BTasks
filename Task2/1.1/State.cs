namespace Task2._1._1;

public class State
{
    //private
    string name;
    int defaultVar;
    private int privateVar;
    protected int protectedVar;
    internal int internalVar;
    protected internal int protectedInternalVar;
    public int publicVar;
    
    //private
    void Print()
    {
        Console.WriteLine(name);
    }

    void defaultMethod() => Console.WriteLine($"defaultVal = {defaultVar}");
    
    private void privateMethod() => Console.WriteLine($"privateVar = {privateVar}");
 
    protected void protectedMethod()=> Console.WriteLine($"protectedVar = {protectedVar}");
     
    internal void internalMethod() => Console.WriteLine($"internalVar = {internalVar}");
     
    protected internal void protectedInternalMethod() => Console.WriteLine($"protectedInternalVar = {protectedInternalVar}");
     
    public void publicMethod() => Console.WriteLine($"publicVar = {publicVar}");
    
    //1.8
    public void Add(int a, int b)
    {
        int result = a + b;
        Console.WriteLine($"Result is {result}");
    }
    public void Add(int a1, int b1)
    {
        int result = a + b;
        Console.WriteLine($"Result is {result}");
    }
}