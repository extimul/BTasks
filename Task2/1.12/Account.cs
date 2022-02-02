namespace Task2._1._12;

public static class Account
{
    private static decimal minSum = 100;

    //ошибка: не было ключевого слова static
    public static decimal MinSum
    {
        get => minSum;
        set
        {
            if (value > 0)
            {
                minSum = value;
            }
        }
    }
    
    public static decimal GetSum(decimal sum, decimal rate, int period)
    {
        decimal result = sum;
        for (int i = 1; i <= period; i++)
            result = result + result * rate / 100;
        return result;
    }
}