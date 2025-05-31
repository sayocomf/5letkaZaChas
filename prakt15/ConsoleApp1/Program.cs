using System;

public class MathAndConvertOperations
{
    // 1. Вычисление гипотенузы
    public static double CalculateHypotenuse(double a, double b)
    {
        return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
    }

    // 2. Округление чисел
    public static void RoundNumber(double number, out double floor, out double ceiling)
    {
        floor = Math.Floor(number);
        ceiling = Math.Ceiling(number);
    }

    // 3. Тригонометрические функции
    public static void CalculateTrigonometricFunctions(double angleDegrees)
    {
        double angleRadians = angleDegrees * Math.PI / 180;
        double sin = Math.Sin(angleRadians);
        double cos = Math.Cos(angleRadians);
        double tan = Math.Tan(angleRadians);

        Console.WriteLine($"Синус: {sin:F4}, Косинус: {cos:F4}, Тангенс: {tan:F4}");
    }

    // 4. Генератор случайных чисел
    public static void GenerateRandomNumbers()
    {
        Random random = new Random();
        Console.WriteLine("10 случайных чисел от 1 до 100:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write(random.Next(1, 101) + " ");
        }
        Console.WriteLine();
    }

    // 5. Минимум и максимум
    public static (double min, double max) FindMinMax(double[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            throw new ArgumentException("Массив не может быть пустым");

        double min = numbers[0];
        double max = numbers[0];

        foreach (var num in numbers)
        {
            min = Math.Min(min, num);
            max = Math.Max(max, num);
        }

        return (min, max);
    }

    // 6. Конвертация строки в число
    public static void ConvertStringToInt()
    {
        Console.Write("Введите число: ");
        string input = Console.ReadLine();

        try
        {
            int number = Convert.ToInt32(input);
            Console.WriteLine($"Успешно преобразовано: {number}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введенная строка не является числом.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка: число слишком большое или слишком маленькое.");
        }
    }

    // 7. Преобразование числа в двоичную строку
    public static string ConvertToBinary(int number)
    {
        return Convert.ToString(number, 2);
    }

    // 8. Конвертация даты
    public static DateTime ConvertStringToDateTime(string dateString)
    {
        return Convert.ToDateTime(dateString);
    }

    // 9. Изменение типа данных
    public static double ConvertObjectToDouble(object obj)
    {
        try
        {
            return Convert.ToDouble(obj);
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("Невозможно преобразовать объект в double");
            return double.NaN;
        }
        catch (FormatException)
        {
            Console.WriteLine("Неверный формат числа");
            return double.NaN;
        }
        catch (OverflowException)
        {
            Console.WriteLine("Число слишком большое или слишком маленькое");
            return double.NaN;
        }
    }

    // 10. Работа с булевыми значениями
    public static bool ConvertToBoolean(string input)
    {
        try
        {
            if (string.Equals(input, "True", StringComparison.OrdinalIgnoreCase))
                return true;
            if (string.Equals(input, "False", StringComparison.OrdinalIgnoreCase))
                return false;

            return Convert.ToBoolean(Convert.ToInt32(input));
        }
        catch (FormatException)
        {
            Console.WriteLine("Невозможно преобразовать строку в boolean");
            return false;
        }
    }

    public static void DemonstrateAllFunctions()
    {
        Console.WriteLine("1. Гипотенуза с катетами 3 и 4: " + CalculateHypotenuse(3, 4));

        RoundNumber(3.7, out double floor, out double ceiling);
        Console.WriteLine($"2. Округление 3.7: вниз = {floor}, вверх = {ceiling}");

        Console.WriteLine("3. Тригонометрические функции для 30 градусов:");
        CalculateTrigonometricFunctions(30);

        Console.WriteLine("4. Генерация случайных чисел:");
        GenerateRandomNumbers();

        double[] numbers = { 1.5, 2.3, 0.7, 4.8, 3.2 };
        var (min, max) = FindMinMax(numbers);
        Console.WriteLine($"5. Минимальное: {min}, Максимальное: {max}");

        Console.WriteLine("6. Конвертация строки в число:");
        ConvertStringToInt();

        Console.WriteLine("7. Число 10 в двоичной системе: " + ConvertToBinary(10));

        DateTime date = ConvertStringToDateTime("2025-05-26");
        Console.WriteLine($"8. Конвертация даты: {date:dd.MM.yyyy}");

        Console.WriteLine("9. Конвертация объекта '3.14' в double: " + ConvertObjectToDouble("3.14"));

        Console.WriteLine("10. Конвертация в bool:");
        Console.WriteLine("'True' -> " + ConvertToBoolean("True"));
        Console.WriteLine("'0' -> " + ConvertToBoolean("0"));
    }

    public static void Main(string[] args)
    {
        DemonstrateAllFunctions();
    }
}