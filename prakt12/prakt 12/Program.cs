using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString() => $"{Name}, {Age} лет";
}

public class Student : Person
{
    public string University { get; set; }
    public double GPA { get; set; }

    public Student(string name, int age, string university, double gpa)
        : base(name, age)
    {
        University = university;
        GPA = gpa;
    }

    public Person BasePerson => new Person(Name, Age);

    public override string ToString() => $"{base.ToString()}, {University}, GPA: {GPA:F2}";
}

public struct StudentStruct
{
    public string LastName;
    public string FirstName;
    public int Course;
    public int MathScore;
    public int PhysicsScore;
    public int InformaticsScore;

    public double AverageScore => (MathScore + PhysicsScore + InformaticsScore) / 3.0;

    public override string ToString() =>
        $"{LastName} {FirstName}, курс {Course}, средний балл: {AverageScore:F2}";
}

class Program
{
    #region Задача 1: Работа с коллекциями (ArrayList, Queue, Hashtable)
    static void Task1()
    {
        Console.WriteLine("\n=== Задача 1: Работа с базовыми коллекциями ===");

        Console.WriteLine("\n--- ArrayList ---");
        ArrayList arrayList = new ArrayList();

        try
        {
            arrayList.Add(3.14);
            arrayList.Add(2.71);
            arrayList.Add(1.618);
            arrayList.Add(0.577);

            Console.WriteLine("Элементы ArrayList:");
            foreach (double item in arrayList)
                Console.WriteLine(item);

            Console.WriteLine($"Элемент с индексом 1: {arrayList[1]}");

            arrayList.Remove(2.71);
            Console.WriteLine("После удаления 2.71:");
            foreach (double item in arrayList)
                Console.WriteLine(item);

            Console.WriteLine($"Содержит 3.14? {arrayList.Contains(3.14)}");

            Console.WriteLine(arrayList[10]);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine($"Ошибка приведения типа: {ex.Message}");
        }

        Console.WriteLine("\n--- Queue ---");
        Queue queue = new Queue();

        try
        {
            queue.Enqueue(5.5);
            queue.Enqueue(6.6);
            queue.Enqueue(7.7);

            Console.WriteLine("Элементы Queue:");
            foreach (double item in queue)
                Console.WriteLine(item);

            Console.WriteLine($"Извлеченный элемент: {queue.Dequeue()}");
            Console.WriteLine($"Следующий элемент: {queue.Peek()}");

            queue.Clear();
            Console.WriteLine($"Очередь пуста? {queue.Count == 0}");

            Console.WriteLine(queue.Dequeue());
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка операции: {ex.Message}");
        }

        Console.WriteLine("\n--- Hashtable ---");
        Hashtable hashtable = new Hashtable();

        try
        {
            hashtable.Add("pi", 3.14);
            hashtable.Add("e", 2.71);
            hashtable["golden"] = 1.618;

            Console.WriteLine("Элементы Hashtable:");
            foreach (DictionaryEntry entry in hashtable)
                Console.WriteLine($"{entry.Key}: {entry.Value}");

            Console.WriteLine($"Содержит ключ 'pi'? {hashtable.ContainsKey("pi")}");

            hashtable.Remove("e");
            Console.WriteLine("После удаления 'e':");
            foreach (DictionaryEntry entry in hashtable)
                Console.WriteLine($"{entry.Key}: {entry.Value}");

            hashtable.Add("pi", 3.1415926535);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка аргумента: {ex.Message}");
        }
    }
    #endregion

    #region Задача 2: Метод обработки коллекции с ref
    static void ProcessCollection(ref ArrayList collection)
    {
        if (collection == null || collection.Count == 0)
            throw new ArgumentException("Коллекция пуста или не инициализирована");

        double sum = 0;
        foreach (double item in collection)
            sum += item;
        double average = sum / collection.Count;

        Console.WriteLine($"Среднее арифметическое: {average}");

        for (int i = 0; i < collection.Count; i++)
        {
            if ((double)collection[i] < average)
                collection[i] = 0.0;
        }

        Console.WriteLine("Коллекция после обработки:");
        foreach (double item in collection)
            Console.WriteLine(item);
    }

    static void Task2()
    {
        Console.WriteLine("\n=== Задача 2: Метод обработки коллекции с ref ===");

        ArrayList numbers = new ArrayList() { 10.5, 5.2, 8.7, 3.3, 7.1, 12.4 };

        try
        {
            ProcessCollection(ref numbers);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
    #endregion

    #region Задача 3: Проверка скобочной структуры
    static bool IsBracketStructureValid(string input)
    {
        Stack stack = new Stack();

        try
        {
            foreach (char c in input)
            {
                if (c == '(')
                    stack.Push(c);
                else if (c == ')')
                {
                    if (stack.Count == 0)
                        return false;
                    stack.Pop();
                }
                else
                    throw new ArgumentException("Строка содержит недопустимые символы");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            return false;
        }

        return stack.Count == 0;
    }

    static void Task3()
    {
        Console.WriteLine("\n=== Задача 3: Проверка скобочной структуры ===");

        string[] testCases = { "()", "(()())", "())(", "((()))", ")(())", "((())())" };

        foreach (string test in testCases)
            Console.WriteLine($"'{test}': {(IsBracketStructureValid(test) ? "правильно" : "неправильно")}");
    }
    #endregion

    #region Задача 4: Работа со студентами
    static void Task4()
    {
        Console.WriteLine("\n=== Задача 4: Работа со студентами ===");

        StudentStruct[] students = {
            new StudentStruct { LastName = "Иванов", FirstName = "Иван", Course = 2, MathScore = 4, PhysicsScore = 5, InformaticsScore = 5 },
            new StudentStruct { LastName = "Петров", FirstName = "Петр", Course = 1, MathScore = 3, PhysicsScore = 3, InformaticsScore = 4 },
            new StudentStruct { LastName = "Сидоров", FirstName = "Сидор", Course = 2, MathScore = 3, PhysicsScore = 3, InformaticsScore = 3 },
            new StudentStruct { LastName = "Кузнецов", FirstName = "Алексей", Course = 3, MathScore = 5, PhysicsScore = 5, InformaticsScore = 5 },
            new StudentStruct { LastName = "Смирнова", FirstName = "Мария", Course = 2, MathScore = 4, PhysicsScore = 4, InformaticsScore = 3 },
            new StudentStruct { LastName = "Васильев", FirstName = "Василий", Course = 4, MathScore = 5, PhysicsScore = 4, InformaticsScore = 5 }
        };

        StudentStruct worstStudent = default;
        bool found = false;
        double minAverage = double.MaxValue;

        foreach (var student in students)
        {
            if (student.Course == 2 && student.AverageScore < minAverage)
            {
                worstStudent = student;
                minAverage = student.AverageScore;
                found = true;
            }
        }

        Console.WriteLine(found
            ? $"Худший студент 2-го курса (массив): {worstStudent.LastName} {worstStudent.FirstName}"
            : "Студенты 2-го курса не найдены");

        Queue studentQueue = new Queue(students);

        worstStudent = default;
        found = false;
        minAverage = double.MaxValue;

        foreach (StudentStruct student in studentQueue)
        {
            if (student.Course == 2 && student.AverageScore < minAverage)
            {
                worstStudent = student;
                minAverage = student.AverageScore;
                found = true;
            }
        }

        Console.WriteLine(found
            ? $"Худший студент 2-го курса (очередь): {worstStudent.LastName} {worstStudent.FirstName}"
            : "Студенты 2-го курса не найдены");
    }
    #endregion

    #region Задача 5: Тестирование коллекций
    class TestCollections
    {
        public List<Student> StudentList { get; } = new List<Student>();
        public List<string> StringList { get; } = new List<string>();
        public Dictionary<Student, Person> StudentDict { get; } = new Dictionary<Student, Person>();
        public Dictionary<string, Person> StringDict { get; } = new Dictionary<string, Person>();

        public TestCollections(int count)
        {
            if (count <= 0)
                throw new ArgumentException("Количество элементов должно быть положительным", nameof(count));

            for (int i = 1; i <= count; i++)
            {
                var student = new Student(
                    $"Студент{i}",
                    18 + i % 5,
                    $"Университет{i % 3 + 1}",
                    3.0 + i % 4 * 0.5);

                var person = student.BasePerson;

                StudentList.Add(student);
                StringList.Add(student.ToString());
                StudentDict.Add(student, person);
                StringDict.Add(student.ToString(), person);
            }
        }

        public void MeasurePerformance()
        {
            if (StudentList.Count == 0) return;

            var testItems = new[]
            {
                StudentList[0],
                StudentList[StudentList.Count / 2],
                StudentList[StudentList.Count - 1],
                new Student("Несуществующий", 100, "Тест", 1.0)
            };

            foreach (var item in testItems)
            {
                Console.WriteLine($"\nТестирование элемента: {item}");

                var watch = Stopwatch.StartNew();
                bool containsStudent = StudentList.Contains(item);
                watch.Stop();
                Console.WriteLine($"List<Student>.Contains: {containsStudent}, время: {watch.ElapsedTicks} тиков");

                string itemStr = item.ToString();
                watch.Restart();
                containsStudent = StringList.Contains(itemStr);
                watch.Stop();
                Console.WriteLine($"List<string>.Contains: {containsStudent}, время: {watch.ElapsedTicks} тиков");

                watch.Restart();
                bool containsKey = StudentDict.ContainsKey(item);
                watch.Stop();
                Console.WriteLine($"Dictionary<Student, Person>.ContainsKey: {containsKey}, время: {watch.ElapsedTicks} тиков");

                watch.Restart();
                containsKey = StringDict.ContainsKey(itemStr);
                watch.Stop();
                Console.WriteLine($"Dictionary<string, Person>.ContainsKey: {containsKey}, время: {watch.ElapsedTicks} тиков");

                if (StudentDict.Count > 0)
                {
                    var value = StudentDict.Values.First();
                    watch.Restart();
                    bool containsValue = StudentDict.ContainsValue(value);
                    watch.Stop();
                    Console.WriteLine($"Dictionary<Student, Person>.ContainsValue: {containsValue}, время: {watch.ElapsedTicks} тиков");
                }
            }
        }
    }

    static void Task5()
    {
        Console.WriteLine("\n=== Задача 5: Тестирование коллекций ===");

        try
        {
            var testCollections = new TestCollections(1000);
            testCollections.MeasurePerformance();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
    #endregion

    static void Main()
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
    }
}