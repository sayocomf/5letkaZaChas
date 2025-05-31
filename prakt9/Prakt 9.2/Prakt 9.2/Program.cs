using System;

abstract class AbstractBase
{
    protected int field1;
    protected int field2;

    public AbstractBase(int value1, int value2)
    {
        field1 = value1;
        field2 = value2;
    }

    public abstract int this[int index] { get; set; }
}

interface ICalculator
{
    int Calculate(int multiplier);
}

class CombinedClass : AbstractBase, ICalculator
{
    public CombinedClass(int value1, int value2) : base(value1, value2) { }

    public override int this[int index]
    {
        get
        {
            return index % 2 == 0 ? field1 : field2;
        }
        set
        {
            if (index % 2 == 0)
                field1 = value;
            else
                field2 = value;
        }
    }

    public int Calculate(int multiplier)
    {
        return (field1 + field2) * multiplier;
    }
}

class Program2
{
    static void Main(string[] args)
    {
        CombinedClass obj = new CombinedClass(10, 20);

        Console.WriteLine("Initial values:");
        Console.WriteLine("Even index (0): " + obj[0]);
        Console.WriteLine("Odd index (1): " + obj[1]);

        obj[0] = 30;
        obj[1] = 40;

        Console.WriteLine("Modified values:");
        Console.WriteLine("Even index (0): " + obj[0]);
        Console.WriteLine("Odd index (1): " + obj[1]);

        Console.WriteLine("Calculate with multiplier 3: " + obj.Calculate(3));
    }
}