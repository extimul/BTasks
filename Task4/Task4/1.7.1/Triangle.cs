namespace Task4._1._7._1;

public class Triangle : Figure
{
    public double Height { get; set; }
    public double SideHeight { get; set; }

    public Triangle(double height, double sideHeight)
    {
        Height = height;
        SideHeight = sideHeight;
        GetArea();
    }

    public sealed override void GetArea()
    {
        Area = (SideHeight * Height) / 2;
    }

    public override void GetPerimeter()
    {
        Perimeter = 0;
    }

    public override void GetInfo()
    {
        Console.WriteLine($"Triangle Area: {Area}; Triangle Perimeter: {Perimeter}");
    }
}