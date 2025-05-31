using System;

// Задание 1
class State
{
    public decimal Population { get; set; }
    public decimal Area { get; set; }

    public static State operator +(State state1, State state2)
    {
        return new State
        {
            Population = state1.Population + state2.Population,
            Area = state1.Area + state2.Area
        };
    }

    public static bool operator >(State state1, State state2)
    {
        return state1.Population > state2.Population;
    }

    public static bool operator <(State state1, State state2)
    {
        return state1.Population < state2.Population;
    }
}

// Задание 2
class Bread
{
    public int Weight { get; set; }

    public static Sandwich operator +(Bread bread, Butter butter)
    {
        return new Sandwich
        {
            Weight = bread.Weight + butter.Weight
        };
    }
}

class Butter
{
    public int Weight { get; set; }
}

class Sandwich
{
    public int Weight { get; set; }
}

// Задание 3
class MyClass
{
    public int Number { get; set; }
    public string Text { get; set; }

    public static bool operator >(MyClass a, MyClass b)
    {
        return a.Text.Length > b.Text.Length;
    }

    public static bool operator <(MyClass a, MyClass b)
    {
        return a.Text.Length < b.Text.Length;
    }

    public static bool operator >=(MyClass a, MyClass b)
    {
        return a.Number >= b.Number;
    }

    public static bool operator <=(MyClass a, MyClass b)
    {
        return a.Number <= b.Number;
    }

    public static bool operator ==(MyClass a, MyClass b)
    {
        return a.Number == b.Number && a.Text == b.Text;
    }

    public static bool operator !=(MyClass a, MyClass b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (obj is not MyClass other) return false;
        return this == other;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Number, Text);
    }
}

// Задание 4
class MyNumber
{
    public int Value { get; set; }

    public static bool operator true(MyNumber num)
    {
        return num.Value == 2 || num.Value == 3 || num.Value == 5 || num.Value == 7;
    }

    public static bool operator false(MyNumber num)
    {
        return num.Value < 1 || num.Value > 10;
    }

    public static MyNumber operator &(MyNumber a, MyNumber b)
    {
        return new MyNumber { Value = (a ? 1 : 0) & (b ? 1 : 0) };
    }

    public static MyNumber operator |(MyNumber a, MyNumber b)
    {
        return new MyNumber { Value = (a ? 1 : 0) | (b ? 1 : 0) };
    }
}

// Задание 5
class Clock
{
    public int Hours { get; set; }

    public static implicit operator Clock(int hours)
    {
        return new Clock { Hours = hours % 24 };
    }

    public static explicit operator int(Clock clock)
    {
        return clock.Hours;
    }
}

// Задание 6
class Celcius
{
    public double Gradus { get; set; }

    public static explicit operator Celcius(Fahrenheit f)
    {
        return new Celcius { Gradus = 5.0 / 9 * (f.Gradus - 32) };
    }

    public static explicit operator Fahrenheit(Celcius c)
    {
        return new Fahrenheit { Gradus = 9.0 / 5 * c.Gradus + 32 };
    }
}

class Fahrenheit
{
    public double Gradus { get; set; }
}

// Задание 7
class Dollar
{
    public decimal Sum { get; set; }

    public static explicit operator Euro(Dollar dollar)
    {
        return new Euro { Sum = dollar.Sum / 1.14m };
    }

    public static implicit operator Dollar(Euro euro)
    {
        return new Dollar { Sum = euro.Sum * 1.14m };
    }
}

class Euro
{
    public decimal Sum { get; set; }
}

// Задание 8
class TextHolder
{
    public string Text { get; set; }

    public static explicit operator int(TextHolder th)
    {
        return th.Text.Length;
    }

    public static explicit operator char(TextHolder th)
    {
        return th.Text.Length > 0 ? th.Text[0] : '\0';
    }

    public static implicit operator TextHolder(int length)
    {
        return new TextHolder { Text = new string('А', length) };
    }
}

class Program
{
    static void Main()
    {
        // Тестирование задания 1
        State state1 = new State { Population = 10, Area = 100 };
        State state2 = new State { Population = 20, Area = 200 };
        State state3 = state1 + state2;
        bool isGreater = state1 > state2;
        Console.WriteLine($"Задание 1: {state3.Population}, {state3.Area}, {isGreater}");

        // Тестирование задания 2
        Bread bread = new Bread { Weight = 80 };
        Butter butter = new Butter { Weight = 20 };
        Sandwich sandwich = bread + butter;
        Console.WriteLine($"Задание 2: {sandwich.Weight}");

        // Тестирование задания 3
        MyClass obj1 = new MyClass { Number = 1, Text = "abc" };
        MyClass obj2 = new MyClass { Number = 2, Text = "abcd" };
        Console.WriteLine($"Задание 3: {obj1 > obj2}, {obj1 <= obj2}, {obj1 == obj2}");

        // Тестирование задания 4
        MyNumber num1 = new MyNumber { Value = 3 };
        MyNumber num2 = new MyNumber { Value = 8 };
        if (num1 && num2) Console.WriteLine("Задание 4: Оба истинны");
        if (num1 || num2) Console.WriteLine("Задание 4: Хотя бы один истинен");

        // Тестирование задания 5
        Clock clock = new Clock();
        int val = 34;
        clock = val; // неявное преобразование
        val = (int)clock; // явное преобразование
        Console.WriteLine($"Задание 5: {clock.Hours}, {val}");

        // Тестирование задания 6
        Celcius c = new Celcius { Gradus = 100 };
        Fahrenheit f = (Fahrenheit)c;
        Console.WriteLine($"Задание 6: {f.Gradus}");

        // Тестирование задания 7
        Dollar dollar = new Dollar { Sum = 100 };
        Euro euro = (Euro)dollar; // явное преобразование
        dollar = euro; // неявное преобразование
        Console.WriteLine($"Задание 7: {euro.Sum}, {dollar.Sum}");

        // Тестирование задания 8
        TextHolder th = new TextHolder { Text = "Пример" };
        int length = (int)th;
        char first = (char)th;
        TextHolder th2 = 5; // неявное преобразование
        Console.WriteLine($"Задание 8: {length}, {first}, {th2.Text}");
    }
}