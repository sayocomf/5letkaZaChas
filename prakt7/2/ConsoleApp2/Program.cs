using System;

class Program
{
    delegate double QuadraticFunction(double x);

    static QuadraticFunction GetQuadraticFunction(double a, double b, double c)
    {
        return x => a * x * x + b * x + c;
    }

    static void Main()
    {
        var quadFunc = GetQuadraticFunction(1, 2, 1);

        Console.WriteLine(quadFunc(0)); 
        Console.WriteLine(quadFunc(1));
        Console.WriteLine(quadFunc(2));
    }
}