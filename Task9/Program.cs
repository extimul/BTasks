
namespace Task9;

class Program
{
    private static void Main()
    {
        //1.1
        Calculate calculate = GetCircleArea;
        calculate += GetCircleLength;
        calculate += GetSphereVolume;

        var a = new List<int>();

        var t = a.Select(x => new
        {
            Ty = x
        });
        
        Console.WriteLine(calculate.Invoke(12));
        
        //3.1
        //TaskClass task = new TaskClass(); 
        
        //3.2
        
    }
    
    private static double GetCircleLength(double radius) => 2 * Math.PI * radius;

    private static double GetCircleArea(double radius) => Math.PI * Math.Pow(radius, 2);

    private static double GetSphereVolume(double radius) => 4 / 3 * Math.PI * Math.Pow(radius, 3);

    delegate double Calculate(double value);
}