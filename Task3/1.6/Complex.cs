namespace Task3._1._6;

public class Complex
{
    private readonly double _real;
    private readonly double _i;
    
    public Complex(double real, double i)
    {
        _real = real;
        _i = i;
    }

    public static Complex operator +(Complex a, Complex b) => new(a._real + b._real, a._i + b._i);

    public static Complex operator -(Complex a, Complex b) => new(a._real - b._real, a._i - b._i);

    public static Complex operator *(Complex a, Complex b) =>
        new(a._real * b._real - a._i * b._i, a._real * b._i + b._i * b._real);

    public static Complex operator /(Complex a, Complex b) => 
        new((a._real * b._real + a._i * a._i) / (Math.Pow(a._real, 2) + Math.Pow(a._real, 2)), 
            (b._real * a._i - a._real * b._i) / (Math.Pow(b._real,2) + Math.Pow(b._i,2)));

    public static bool operator ==(Complex a, Complex b) => a.Equals(b);

    public static bool operator !=(Complex a, Complex b) => !a.Equals(b);

    public override bool Equals(object? obj)
    {
        try { return base.Equals((Complex) obj!); }
        catch { return false; }
    }

    public override int GetHashCode() => this._real.GetHashCode() + this._i.GetHashCode();

    public override string ToString()
    {
        // return $"Real: {_real}; Indeterminate: {_i}";
        return this._real.ToString() + (this._i < 0 ? " " : " + ") + this._i.ToString() + 'i';
    }
}