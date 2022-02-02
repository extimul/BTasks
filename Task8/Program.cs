namespace Task8;

class Program
{
    delegate void Message();

    delegate void SomeDel();

    delegate void Delegate1();
    
    delegate int Operation(int a, int b);

    delegate T Square<T, K>(K value);

    // delegate int Square<T>(T value);

    // delegate T Square<T>(double value);

    private static void Main()
    {

        // Message mes = SayHi;
        //  mes += SayHi;
        //  mes();

         SomeDel del = M1;
         del += M2;
         del.Invoke();
        
        //1.2
        // Delegate1 d1 = SayHi;
        // Delegate1 d2 = M1; 
        // Delegate1 d3 = d1 + d2;
        // d3.Invoke();
        //
        // Square<int, int> d = CalcSquare;
        // d.Invoke(5);
        
        //1.7
        // Operation op = Multiply;
        // Calculate(1,2, op);
    }

    private static int CalcSquare(int n) => n * n;

    public static void SayHi()
    {
        Console.WriteLine("Hi");
    }

    private static void M1()
    {
        Console.WriteLine("M1");
    }
    
    private static void M2()
    {
        Console.WriteLine("M2");
    }

    private static void Calculate(int a, int b, Operation operation)
    {
        operation(a, b);
    }

    private static int Multiply(int a, int b)
    {
        return a * b;
    }
}

