using System;

// Задание 1 и 2: Классы футболиста и команды с безопасным индексатором
class Player
{
    public string Name { get; set; }
    public int Number { get; set; }
}

class Team
{
    Player[] players = new Player[11];

    public Player this[int index]
    {
        get
        {
            if (index < 0 || index >= players.Length)
                return null;
            return players[index];
        }
        set
        {
            if (index >= 0 && index < players.Length)
                players[index] = value;
        }
    }
}

// Задание 3: Словарь с индексатором по слову
class Word
{
    public string Source { get; }
    public string Target { get; set; }
    public Word(string source, string target)
    {
        Source = source;
        Target = target;
    }
}

class Dictionary
{
    Word[] words;
    public Dictionary()
    {
        words = new Word[]
        {
            new Word("red", "красный"),
            new Word("blue", "синий"),
            new Word("green", "зеленый")
        };
    }

    public string this[string source]
    {
        get
        {
            foreach (Word word in words)
            {
                if (word.Source == source)
                    return word.Target;
            }
            return null;
        }
        set
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Source == source)
                {
                    words[i].Target = value;
                    break;
                }
            }
        }
    }
}

// Задание 4: Класс с циклическим свойством для массива
class CyclicArray
{
    private int[] array;
    private int currentIndex = 0;

    public CyclicArray(int[] values)
    {
        array = values;
    }

    public int CurrentValue
    {
        get
        {
            int value = array[currentIndex];
            currentIndex = (currentIndex + 1) % array.Length;
            return value;
        }
        set
        {
            array[currentIndex] = value;
        }
    }
}

// Задание 5: Класс с индексатором для изменения разрядов числа
class DigitChanger
{
    private uint number = 0;

    public uint Number
    {
        get { return number; }
        set { number = value; }
    }

    public int this[int digitPosition]
    {
        set
        {
            int digit = value % 10;
            uint power = (uint)Math.Pow(10, digitPosition);
            uint currentDigitValue = (number / power) % 10;
            number = number - currentDigitValue * power + (uint)digit * power;
        }
    }
}

// Задание 6: Класс с одномерным и двумерным индексаторами для текстового массива
class TextArray
{
    private string[] texts;

    public TextArray(string[] array)
    {
        texts = array;
    }

    // Одномерный индексатор
    public string this[int index]
    {
        get
        {
            index = index % texts.Length;
            if (index < 0) index += texts.Length;
            return texts[index];
        }
        set
        {
            index = index % texts.Length;
            if (index < 0) index += texts.Length;
            texts[index] = value;
        }
    }

    // Двумерный индексатор
    public char this[int textIndex, int charIndex]
    {
        get
        {
            textIndex = textIndex % texts.Length;
            if (textIndex < 0) textIndex += texts.Length;

            string text = texts[textIndex];
            charIndex = charIndex % text.Length;
            if (charIndex < 0) charIndex += text.Length;

            return text[charIndex];
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Тестирование классов

        // Задание 1 и 2
        Team team = new Team();
        team[0] = new Player { Name = "Ronaldo", Number = 7 };
        Console.WriteLine($"Игрок 0: {team[0]?.Name}");
        Console.WriteLine($"Игрок 20: {team[20]?.Name ?? "null"}");

        // Задание 3
        Dictionary dict = new Dictionary();
        Console.WriteLine($"Перевод 'red': {dict["red"]}");
        dict["red"] = "рубиновый";
        Console.WriteLine($"Новый перевод 'red': {dict["red"]}");

        // Задание 4
        CyclicArray cyclic = new CyclicArray(new int[] { 1, 2, 3 });
        Console.WriteLine("\nЦиклический массив:");
        for (int i = 0; i < 5; i++)
            Console.WriteLine(cyclic.CurrentValue);

        // Задание 5
        DigitChanger dc = new DigitChanger();
        dc.Number = 123;
        dc[1] = 5; // Изменяем десятки
        Console.WriteLine($"\nЧисло после изменения: {dc.Number}");

        // Задание 6
        TextArray textArray = new TextArray(new string[] { "hello", "world" });
        Console.WriteLine($"\nТекст с индексом 3: {textArray[3]}");
        Console.WriteLine($"Символ [1,10]: {textArray[1, 10]}");
    }
}