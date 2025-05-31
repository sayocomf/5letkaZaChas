using System;

class Program
{
    delegate string GetDayDelegate();

    static void Main()
    {
        int currentDay = 0;
        string[] days = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };

        GetDayDelegate getDay = () => {
            string day = days[currentDay % 7];
            currentDay++;
            return day;
        };

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(getDay());
        }
    }
}