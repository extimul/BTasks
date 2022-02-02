namespace Task4._1._7._2;

public class Triangle : IFigure
{
    private readonly double _sideLength;
    private readonly double _height;
    
    public double Area { get; set; }
    public double Perimeter { get; set; }

    public Triangle(double sideLength, double height)
    {
        _sideLength = sideLength;
        _height = height;
    }
    
    public void GetArea()
    {
        Area = (_sideLength * _height) / 2;
    }

    public void GetPerimeter()
    {
        Perimeter = 0;
    }

    public void GetInfo()
    {
        Console.WriteLine($"Triangle Area: {Area}; Triangle Perimeter: {Perimeter}");
    }
}