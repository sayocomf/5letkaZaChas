using System;
using System.Threading;
using System.Globalization;

class DateTimeTasks
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите задачу:");
            Console.WriteLine("1. Разница между двумя датами");
            Console.WriteLine("2. Определение дня недели");
            Console.WriteLine("3. Добавление дней к дате");
            Console.WriteLine("4. Проверка високосного года");
            Console.WriteLine("5. Форматирование даты и времени");
            Console.WriteLine("6. Сколько дней до Нового года?");
            Console.WriteLine("7. Возраст человека");
            Console.WriteLine("8. Валидация даты");
            Console.WriteLine("9. Часовые пояса");
            Console.WriteLine("10. Таймер обратного отсчёта");
            Console.WriteLine("0. Выход");
            Console.Write("Ваш выбор: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                continue;
            }

            switch (choice)
            {
                case 1: DateDifference(); break;
                case 2: DayOfWeek(); break;
                case 3: AddDaysToDate(); break;
                case 4: LeapYearCheck(); break;
                case 5: DateFormatting(); break;
                case 6: DaysToNewYear(); break;
                case 7: CalculateAge(); break;
                case 8: ValidateDate(); break;
                case 9: TimeZoneConversion(); break;
                case 10: CountdownTimer(); break;
                case 0: return;
                default: Console.WriteLine("Некорректный выбор. Попробуйте снова."); break;
            }
        }
    }

    static void DateDifference()
    {
        Console.WriteLine("\n1. Разница между двумя датами");
        Console.WriteLine("Введите первую дату (формат dd.MM.yyyy HH:mm):");
        DateTime date1 = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
        Console.WriteLine("Введите вторую дату (формат dd.MM.yyyy HH:mm):");
        DateTime date2 = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

        TimeSpan difference = date1 > date2 ? date1 - date2 : date2 - date1;
        Console.WriteLine($"Разница: {difference.Days} дней, {difference.Hours} часов, {difference.Minutes} минут");
    }

    static void DayOfWeek()
    {
        Console.WriteLine("\n2. Определение дня недели");
        Console.WriteLine("Введите дату (формат dd.MM.yyyy):");
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
        Console.WriteLine($"День недели: {date.ToString("dddd", new CultureInfo("ru-RU"))}");
    }

    static void AddDaysToDate()
    {
        Console.WriteLine("\n3. Добавление дней к дате");
        Console.WriteLine("Введите дату (формат dd.MM.yyyy):");
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
        Console.WriteLine("Введите количество дней для добавления:");
        int days = int.Parse(Console.ReadLine());

        DateTime newDate = date.AddDays(days);
        Console.WriteLine($"Новая дата: {newDate:dd.MM.yyyy}");
    }

    static void LeapYearCheck()
    {
        Console.WriteLine("\n4. Проверка високосного года");
        Console.WriteLine("Введите год:");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine($"{year} {(DateTime.IsLeapYear(year) ? "високосный" : "не високосный")}");
    }

    static void DateFormatting()
    {
        Console.WriteLine("\n5. Форматирование даты и времени");
        Console.WriteLine("Введите дату и время (формат dd.MM.yyyy HH:mm):");
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

        Console.WriteLine($"Форматы:");
        Console.WriteLine($"dd.MM.yyyy: {date:dd.MM.yyyy}");
        Console.WriteLine($"MM/dd/yyyy: {date:MM/dd/yyyy}");
        Console.WriteLine($"yyyy-MM-dd HH:mm:ss: {date:yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine($"dddd, dd MMMM yyyy: {date.ToString("dddd, dd MMMM yyyy", new CultureInfo("ru-RU"))}");
    }

    static void DaysToNewYear()
    {
        Console.WriteLine("\n6. Сколько дней до Нового года?");
        DateTime now = DateTime.Now;
        DateTime newYear = new DateTime(now.Year + 1, 1, 1);
        TimeSpan remaining = newYear - now;
        Console.WriteLine($"До Нового года осталось {remaining.Days} дней и {remaining.Hours} часов");
    }

    static void CalculateAge()
    {
        Console.WriteLine("\n7. Возраст человека");
        Console.WriteLine("Введите дату рождения (формат dd.MM.yyyy):");
        DateTime birthDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
        DateTime now = DateTime.Now;

        int years = now.Year - birthDate.Year;
        if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
        {
            years--;
        }

        DateTime lastBirthday = birthDate.AddYears(years);
        TimeSpan ageTime = now - lastBirthday;
        int months = (int)(ageTime.Days / 30.436875);
        int days = (int)(ageTime.Days % 30.436875);

        Console.WriteLine($"Возраст: {years} лет, {months} месяцев, {days} дней");
    }

    static void ValidateDate()
    {
        Console.WriteLine("\n8. Валидация даты");
        Console.WriteLine("Введите дату для проверки:");
        string input = Console.ReadLine();
        if (DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
        {
            Console.WriteLine("Дата валидна");
        }
        else
        {
            Console.WriteLine("Дата невалидна");
        }
    }

    static void TimeZoneConversion()
    {
        Console.WriteLine("\n9. Часовые пояса");
        DateTime utcNow = DateTime.UtcNow;
        Console.WriteLine($"Текущее время UTC: {utcNow:dd.MM.yyyy HH:mm}");

        Console.WriteLine("Введите ваш часовой пояс (например, +3 для Москвы):");
        int timeZone = int.Parse(Console.ReadLine());
        DateTime localTime = utcNow.AddHours(timeZone);
        Console.WriteLine($"Ваше локальное время: {localTime:dd.MM.yyyy HH:mm}");

        Console.WriteLine("Конвертация обратно в UTC:");
        DateTime backToUtc = localTime.AddHours(-timeZone);
        Console.WriteLine($"UTC: {backToUtc:dd.MM.yyyy HH:mm}");
    }

    static void CountdownTimer()
    {
        Console.WriteLine("\n10. Таймер обратного отсчёта");
        Console.WriteLine("Введите количество секунд:");
        int seconds = int.Parse(Console.ReadLine());

        for (int i = seconds; i >= 0; i--)
        {
            Console.CursorLeft = 0;
            Console.Write($"Осталось: {i} секунд");
            if (i > 0)
            {
                Thread.Sleep(1000);
            }
        }
        Console.WriteLine("\nВремя вышло!");
    }
}