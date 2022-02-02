namespace Task1.Zadanie1and2;

// 1.1
public class Car
{
    public string Name;
    public float Speed;

    public Car(string name) : this(0, name)
    {
        Name = name;
    }

    public Car(float speed, string name)
    {
        Speed = speed;
    }

    public Car(float speed) : this(speed, "s")
    {
        Speed = speed;
    }
}