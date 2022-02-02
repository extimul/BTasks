namespace Task4._1._7._2;

public class Square : IFigure
{
    private readonly double _sideLength;
    private readonly double _height;
    public double Area { get; set; }
    public double Perimeter { get; set; }

    public Square(double sideLength, double height)
    {
        _sideLength = sideLength;
        _height = height;
    }

    public void GetArea()
    {
        Area = Math.Pow(_sideLength, 2);
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