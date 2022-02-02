namespace Task4._1._1;

public class Counter
{
    public int Seconds { get; set; }

    public static implicit operator Counter(int seconds) => new() {Seconds = seconds};

    public static explicit operator int(Counter counter) => counter.Seconds;
}

public abstract class Migration
{
    public abstract void Up();

    public virtual void Down()
    {
        
    }
}

public class A : Migration
{
    public override void Up()
    {
        throw new NotImplementedException();
    }
}