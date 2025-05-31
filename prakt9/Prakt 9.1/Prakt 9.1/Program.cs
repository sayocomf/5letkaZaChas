using System;

abstract class BaseArray
{
    protected int[] array;

    public BaseArray(int size)
    {
        array = new int[size];
    }

    public int Size => array.Length;

    public abstract void Display();

    public int this[int index]
    {
        get => array[index];
        set => array[index] = value;
    }
}

class DerivedArray : BaseArray
{
    public DerivedArray(int size) : base(size) { }

    public override void Display()
    {
        Console.WriteLine("Array elements:");
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

class Program1
{
    static void Main(string[] args)
    {
        DerivedArray arr = new DerivedArray(5);

        for (int i = 0; i < arr.Size; i++)
        {
            arr[i] = i * 10;
        }

        arr.Display();

        Console.WriteLine("Element at index 2: " + arr[2]);
        arr[2] = 100;
        Console.WriteLine("Modified element at index 2: " + arr[2]);
    }
}