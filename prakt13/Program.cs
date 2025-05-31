using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prakt13
{
    internal class Program
    {
        static void Main()
        {
            // Демонстрация работы всех задач
            Console.WriteLine("Задача 1: " + Task1("Текст (с удаляемым фрагментом) остаётся"));
            Console.WriteLine("Задача 2: " + Task2("раз два три раз два", "раз"));
            Console.WriteLine("Задача 3: " + Task3("Слова   разделены   пробелами"));
            Console.WriteLine("Задача 4: " + Task4("Кот ковёр окно КИВИ") + "%");
            Console.WriteLine("Задача 5: " + Task5("a1b2c3d4"));
            Console.WriteLine("Задача 6: " + Task6("Только буквы и пробелы"));
            Console.WriteLine("Задача 7: " + Task7("ABCFGHIJKabc"));
            Console.WriteLine("Задача 8: " + Task8("1234456784"));
            Console.WriteLine("Задача 9: " + Task9("a1b22c"));
            Console.WriteLine("Задача 10: " + Task10("12390"));
            Console.WriteLine("Задача 11: " + Task11("a1b2c3"));
            Console.WriteLine("Задача 12: " + Task12("abcdef"));
            Console.WriteLine("Задача 13: " + Task13("abcd"));
            Console.WriteLine("Задача 14:\n" + Task14("123456789012345"));

            string s15 = "abc";
            Console.WriteLine("Задача 15: " + Task15(s15));

            Console.WriteLine("Задача 16: " + string.Join(", ", Task16(new[] { "12", "34", "56" })));

            Console.WriteLine("Задача 17: " + string.Join(", ", Task17("a1b", "c2d")));
            Console.WriteLine("Задача 18: " + Task18("ABCFabc"));

            string s19 = "test";
            Task19(ref s19, 3, 'X');
            Console.WriteLine("Задача 19: " + s19);

            string s20 = "t e s t";
            Task20(ref s20);
            Console.WriteLine("Задача 20: " + s20);

            string s21 = "hello";
            Task21(ref s21);
            Console.WriteLine("Задача 21: " + s21);

            string[] s22 = null;
            Task22("abcdefghij", 3, out s22);
            Console.WriteLine("Задача 22: " + string.Join("|", s22));

            string s23 = "ABCDEF";
            Task23(ref s23, 2, 1);
            Console.WriteLine("Задача 23: " + s23);

            string s24 = "A1 текст A1";
            Task24(ref s24, "A1", "A2");
            Console.WriteLine("Задача 24: " + s24);

            string s25 = "hello";
            Task25(ref s25, 'l', 'x');
            Console.WriteLine("Задача 25: " + s25);

            string s26 = "много   пробелов   тут";
            Task26(ref s26);
            Console.WriteLine("Задача 26: " + s26);

            string s27a = "сосна", s27b = "ель", s27c = "дуб";
            Task27(ref s27a); Task27(ref s27b); Task27(ref s27c);
            Console.WriteLine($"Задача 27: {s27a}, {s27b}, {s27c}");

            string s28 = "a1b2";
            Task28(ref s28);
            Console.WriteLine("Задача 28: " + s28);

            string s29 = "п р о б е л ы";
            Task29(ref s29);
            Console.WriteLine("Задача 29: " + s29);

            string s30 = "роза и слон";
            Task30(ref s30);
            Console.WriteLine("Задача 30: " + s30);
        }

        // 1. Удалить текст в скобках
        static string Task1(string input)
        {
            int start;
            while ((start = input.IndexOf('(')) != -1)
            {
                int end = input.IndexOf(')', start);
                if (end == -1) break;
                input = input.Remove(start, end - start + 1);
            }
            return input;
        }

        // 2. Подсчёт количества вхождений слова
        static int Task2(string text, string word)
        {
            return text.Split(' ')
                .Count(w => string.Equals(w, word, StringComparison.OrdinalIgnoreCase));
        }

        // 3. Замена пробелов на ", "
        static string Task3(string text)
        {
            return string.Join(", ", text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        // 4. Процент слов на букву К/к
        static double Task4(string text)
        {
            string[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 0) return 0;
            double count = words.Count(w =>
                w.StartsWith("К", StringComparison.OrdinalIgnoreCase));
            return Math.Round(count / words.Length * 100, 2);
        }

        // 5. Удаление всех цифр
        static string Task5(string input)
        {
            return new string(input.Where(c => !char.IsDigit(c)).ToArray());
        }

        // 6. Проверка на посторонние символы
        static bool Task6(string input)
        {
            return input.Any(c => !char.IsLetter(c) && c != ' ');
        }

        // 7. Удаление символов в ASCII-диапазоне [70,75]
        static string Task7(string input)
        {
            return new string(input.Where(c => c < 70 || c > 75).ToArray());
        }

        // 8. Проверка на наличие "44"
        static bool Task8(string input)
        {
            return input.Contains("44");
        }

        // 9. Вставка пробела после цифры
        static string Task9(string input)
        {
            var sb = new StringBuilder();
            foreach (char c in input)
            {
                sb.Append(c);
                if (char.IsDigit(c)) sb.Append(' ');
            }
            return sb.ToString();
        }

        // 10. Инкремент цифр (9->0)
        static string Task10(string input)
        {
            return new string(input.Select(c =>
                char.IsDigit(c) ? (char)((c - '0' + 1) % 10 + '0') : c
            ).ToArray());
        }

        // 11. Сортировка символов: цифры -> буквы
        static string Task11(string input)
        {
            var digits = input.Where(char.IsDigit);
            var letters = input.Where(char.IsLetter);
            return new string(digits.Concat(letters).ToArray());
        }

        // 12. Конвертация в верхний регистр
        static string Task12(string input)
        {
            return input.ToUpper();
        }

        // 13. Циклический сдвиг символов вправо (ИСПРАВЛЕНО ДЛЯ C# 7.3)
        static string Task13(string input)
        {
            if (input.Length == 0)
                return input;

            return input[input.Length - 1] + input.Substring(0, input.Length - 1);
        }

        // 14. Форматирование цифр группами по 5
        static string Task14(string input)
        {
            var digits = new string(input.Where(char.IsDigit).ToArray());
            var result = new StringBuilder();
            for (int i = 0; i < digits.Length; i += 5)
            {
                int length = Math.Min(5, digits.Length - i);
                result.AppendLine(digits.Substring(i, length));
            }
            return result.ToString();
        }

        // 15. Сдвиг ASCII кодов на +3
        static string Task15(string input)
        {
            return new string(input.Select(c => (char)(c + 3)).ToArray());
        }

        // 16. Сумма цифр кратных 3 в трёх строках
        static int[] Task16(string[] inputs)
        {
            int Sum(string s) => s.Where(char.IsDigit)
                .Select(c => c - '0')
                .Where(d => d % 3 == 0)
                .Sum();

            return inputs.Select(Sum).ToArray();
        }

        // 17. Сумма цифр в двух строках
        static int[] Task17(string s1, string s2)
        {
            int Sum(string s) => s.Where(char.IsDigit)
                .Select(c => c - '0')
                .Sum();

            return new[] { Sum(s1), Sum(s2) };
        }

        // 18. Количество символов с ASCII ≥ 70
        static int Task18(string input)
        {
            return input.Count(c => c >= 70);
        }

        // 19. Добавление символов в конец
        static void Task19(ref string input, int count, char symbol)
        {
            input += new string(symbol, count);
        }

        // 20. Удаление всех пробелов
        static void Task20(ref string input)
        {
            input = input.Replace(" ", "");
        }

        // 21. Зеркальное отображение строки
        static void Task21(ref string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            input = new string(chars);
        }

        // 22. Разбиение на строки по k символов
        static void Task22(string input, int k, out string[] result)
        {
            result = new string[0];
            if (string.IsNullOrEmpty(input)) return;

            var list = new List<string>();
            for (int i = 0; i < input.Length; i += k)
            {
                int length = Math.Min(k, input.Length - i);
                list.Add(input.Substring(i, length));
            }
            result = list.ToArray();
        }

        // 23. Вставка k пробелов каждые n символов
        static void Task23(ref string input, int n, int k)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (i > 0 && i % n == 0)
                    sb.Append(new string(' ', k));
                sb.Append(input[i]);
            }
            input = sb.ToString();
        }

        // 24. Замена слова A1 на A2
        static void Task24(ref string text, string A1, string A2)
        {
            text = text.Replace(A1, A2);
        }

        // 25. Замена символа в строке
        static void Task25(ref string word, char oldChar, char newChar)
        {
            word = word.Replace(oldChar, newChar);
        }

        // 26. Удаление лишних пробелов
        static void Task26(ref string input)
        {
            input = string.Join(" ", input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        // 27. Замена 'с' на 'о' в трёх строках
        static void Task27(ref string input)
        {
            input = input.Replace('с', 'о').Replace('С', 'О');
        }

        // 28. Добавление '!' после цифры
        static void Task28(ref string input)
        {
            var sb = new StringBuilder();
            foreach (char c in input)
            {
                sb.Append(c);
                if (char.IsDigit(c)) sb.Append('!');
            }
            input = sb.ToString();
        }

        // 29. Замена пробелов на подчёркивания
        static void Task29(ref string input)
        {
            input = input.Replace(' ', '_');
        }

        // 30. Удаление букв 'р' и 'с'
        static void Task30(ref string input)
        {
            input = new string(input
                .Where(c => c != 'р' && c != 'с' && c != 'Р' && c != 'С')
                .ToArray());
        }
    }
}