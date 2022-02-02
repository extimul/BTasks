namespace FormulasLibrary;

public static class MathFormulas
{
    public static double CalculateCircleArea(double radius) => Math.PI * Math.Pow(radius, 2);

    public static double CalculateRectangleArea(double length, double height) => length * height;

    public static double CalculateSquareArea(double a) => Math.Pow(a, 2);
}