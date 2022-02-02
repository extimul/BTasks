namespace Task4._1._7._1;

public class Square : Figure
{
    public double SideLength { get; set; }

    public Square(double sideLength)
    {
        SideLength = sideLength;
    }

    public override void GetArea()
    {
        Area = Math.Pow(SideLength, 2);
    }

    public override void GetPerimeter()
    {
        Perimeter = SideLength * 4;
    }

    public override void GetInfo()
    {
        Console.WriteLine($"Area: {Area}; Perimeter: {Perimeter}");
    }
}