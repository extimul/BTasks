namespace Task4._1._7._1;

public abstract class Figure
{
    public double Length { get; set; }

    public double Area { get; set; }

    public double Perimeter { get; set; }

    public abstract void GetArea();
    public abstract void GetPerimeter();
    public abstract void GetInfo();
}