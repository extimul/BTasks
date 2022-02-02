namespace Task4._1._7._1;

public class Circle : Figure
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override void GetArea()
    {
        Area = Math.Pow(Radius, 2) * 2;
    }

    public override void GetPerimeter()
    {
        Perimeter = Radius * 2 * Math.PI;
    }

    public override void GetInfo()
    {
        Console.WriteLine($"Circle Area: {Area}; Circle Perimeter: {Perimeter}; Radius: {Radius}");
    }
}