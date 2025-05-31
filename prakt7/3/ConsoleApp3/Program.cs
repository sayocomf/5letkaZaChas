using System;

class EventGenerator
{
    public string Name { get; }

    public event Action<string> OnEvent;

    public EventGenerator(string name)
    {
        Name = name;
    }

    public void GenerateEvent()
    {
        OnEvent?.Invoke(Name);
    }
}


class EventHandlerClass
{
    public void HandleEvent(string senderName)
    {
        Console.WriteLine($"Событие сгенерировано объектом: {senderName}");
    }
}

class Program
{
    static void Main()
    {
        var generator1 = new EventGenerator("Генератор 1");
        var generator2 = new EventGenerator("Генератор 2");
        var handler = new EventHandlerClass();

        generator1.OnEvent += handler.HandleEvent;
        generator2.OnEvent += handler.HandleEvent;

        generator1.GenerateEvent();
        generator2.GenerateEvent();
    }
}
