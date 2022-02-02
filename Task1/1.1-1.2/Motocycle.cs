namespace Task1.Zadainie1;

// 1.1
public class Motocycle
{
    public string name;

    public string driverIntensity;

    public Motocycle(string driverIntensity)
    {
        this.driverIntensity = driverIntensity;
    }

    public Motocycle(string name, string driverIntensity)
    {
        this.name = name;
        this.driverIntensity = driverIntensity;
    }

    public void SetDriverName(string name)
    {
        this.name = name;
    }
}