using System;

abstract class AbstractClass
{
    public abstract int Property { get; set; }
    public abstract int this[int index] { get; set; }
    public abstract void Method();
}

interface IInterface1
{
    int Property { get; set; }
    int this[int index] { get; set; }
    void Method();
}

interface IInterface2
{
    int Property { get; set; }
    int this[int index] { get; set; }
    void Method();
}

class ImplementationClass : AbstractClass, IInterface1, IInterface2
{
    private int propertyValue;
    private int[] array = new int[10];
    public override int Property
    {
        get => propertyValue;
        set => propertyValue = value;
    }

    public override int this[int index]
    {
        get => array[index];
        set => array[index] = value;
    }

    public override void Method()
    {
        Console.WriteLine("Abstract class method implementation");
    }

    int IInterface1.Property
    {
        get => propertyValue * 2;
        set => propertyValue = value / 2;
    }

    int IInterface1.this[int index]
    {
        get => array[index] * 2;
        set => array[index] = value / 2;
    }

    void IInterface1.Method()
    {
        Console.WriteLine("IInterface1 method implementation");
    }

    int IInterface2.Property
    {
        get => propertyValue * 3;
        set => propertyValue = value / 3;
    }

    int IInterface2.this[int index]
    {
        get => array[index] * 3;
        set => array[index] = value / 3;
    }

    void IInterface2.Method()
    {
        Console.WriteLine("IInterface2 method implementation");
    }
}

class Program3
{
    static void Main(string[] args)
    {
        ImplementationClass obj = new ImplementationClass();

        obj.Property = 10;
        obj[0] = 10;
        Console.WriteLine("Through class reference:");
        Console.WriteLine("Property: " + obj.Property);
        Console.WriteLine("Indexer: " + obj[0]);
        obj.Method();

        IInterface1 i1 = obj;
        i1.Property = 10;
        i1[0] = 10;
        Console.WriteLine("\nThrough IInterface1:");
        Console.WriteLine("Property: " + i1.Property);
        Console.WriteLine("Indexer: " + i1[0]);
        i1.Method();

        IInterface2 i2 = obj;
        i2.Property = 10;
        i2[0] = 10;
        Console.WriteLine("\nThrough IInterface2:");
        Console.WriteLine("Property: " + i2.Property);
        Console.WriteLine("Indexer: " + i2[0]);
        i2.Method();
    }
}