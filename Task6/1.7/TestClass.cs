namespace Task6._1._7;

public class TestClass
{
    public static void Method1()
    {
        try
        {
            Method2();
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Catch в Method1: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Блок finally в Method1");
        }
        Console.WriteLine("Конец метода Method1");
    }
    static void Method2()
    {
        try
        {
            int x = 8;
            int y = x / 0;
        }
        finally
        {
            Console.WriteLine("Блок finally в Method2");
        }
        Console.WriteLine("Конец метода Method2");
    }

}