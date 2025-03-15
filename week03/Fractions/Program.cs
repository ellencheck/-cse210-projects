using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    // Constructors
    public Fraction() : this(1, 1) { }

    public Fraction(int numerator) : this(numerator, 1) { }

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _numerator = numerator;
        _denominator = denominator;
        Simplify(); // Simplify the fraction when it's created
    }

    // Properties for Numerator and Denominator
    public int Numerator
    {
        get => _numerator;
        set => _numerator = value;
    }

    public int Denominator
    {
        get => _denominator;
        set
        {
            if (value == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            _denominator = value;
            Simplify(); // Simplify after changing the denominator
        }
    }

    // Method to simplify the fraction
    private void Simplify()
    {
        int gcd = GCD(Math.Abs(_numerator), Math.Abs(_denominator));
        _numerator /= gcd;
        _denominator /= gcd;
        if (_denominator < 0)  // Ensure the denominator is positive
        {
            _numerator = -_numerator;
            _denominator = -_denominator;
        }
    }

    // Method to calculate the Greatest Common Divisor
    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Methods to return representations
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Your program logic here
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());  // Output: 1/1
        Console.WriteLine(f1.GetDecimalValue());   // Output: 1

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());  // Output: 5/1
        Console.WriteLine(f2.GetDecimalValue());   // Output: 5

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());  // Output: 3/4
        Console.WriteLine(f3.GetDecimalValue());   // Output: 0.75

        Fraction f4 = new Fraction(10, 5);
        Console.WriteLine(f4.GetFractionString());  // Output: 2/1 (simplified)
        Console.WriteLine(f4.GetDecimalValue());   // Output: 2
    }
}
