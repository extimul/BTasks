namespace Task2._1._9;

//1.10
public class Account
{
    public static decimal bonus = 100;
    public decimal totalSum;
    
    public Account(decimal sum)
    {
        totalSum = sum + bonus; 
    }
    
    //1.10
    //был не статическим
    private static decimal minSum = 100;
    public static decimal MinSum
    {
        get { return minSum; }
        set { if(value>0) minSum = value; }
    }
    
}
