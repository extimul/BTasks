namespace Task4._1._7._2;

public class Circle : IFigure
{
    private readonly double _radius;
    public double Area { get; set; }
    public double Perimeter { get; set; }
    
    public Circle(double radius)
    {
        _radius = radius;
    }

    public void GetArea()
    {
        Area = Math.Pow(_radius, 2) * 2;
    }

    public void GetPerimeter()
    {
        Perimeter = _radius * 2 * Math.PI;
    }

    public void GetInfo()
    {
        Console.WriteLine($"Circle Area: {Area}; Circle Perimeter: {Perimeter}; Radius: {_radius}");
    }
}