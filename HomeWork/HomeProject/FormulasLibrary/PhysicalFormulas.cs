namespace FormulasLibrary;

public static class PhysicalFormulas
{
    static PhysicalFormulas()
    {
        Console.WriteLine("Static constructor");
    }

    private const int SpeedOfLight = 299792458;
    
    public static double CalculateVelocity(double displacement, double time) => displacement / time;

    public static double CalculateDensity(double mass, double volume) => mass / volume;

    public static double CalculateEnergy(double mass) => mass * Math.Pow(SpeedOfLight, 2);
}