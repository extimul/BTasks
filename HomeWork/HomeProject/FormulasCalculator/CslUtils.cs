namespace FormulasCalculator;

public static class CslUtils
{
    public static int HandleUserInput() => Convert.ToInt32(Console.ReadLine());

    public static double[] HandleFormulaInput()
    {
        var rawInput = Console.ReadLine();
        if (string.IsNullOrEmpty(rawInput)) return new[] {0.0, 0.0};
        
        var formulaVariables = rawInput.Split(",");
        return Array.ConvertAll(formulaVariables, double.Parse);
    }
    
    public static void DisplayMenu(string[] menuItems)
    {
        for (var i = 1; i < menuItems.Length + 1; i++)
        {
            Console.WriteLine($"{i}.{menuItems[i-1]}");
        }
    }

    public static void Print(object obj) => Console.WriteLine(Convert.ToString(obj));

    public static void Clear() => Console.Clear();
}