using System;

// Базовый класс Animal
public class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    public virtual void MakeSound()
    {
        Console.WriteLine("Some animal sound");
    }
}

// Производный класс Dog
public class Dog : Animal
{
    public Dog(string name) : base(name) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} the dog says: Woof!");
    }

    public void Fetch()
    {
        Console.WriteLine($"{Name} is fetching the stick");
    }
}

// Производный класс Cat
public class Cat : Animal
{
    public Cat(string name) : base(name) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} the cat says: Meow!");
    }

    public void Purr()
    {
        Console.WriteLine($"{Name} is purring");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Демонстрация ковариантности ===");

        // Создаем делегаты для создания животных
        Func<Animal> createAnimal = () => new Animal("Просто животное");
        Func<Dog> createDog = () => new Dog("Шарик");
        Func<Cat> createCat = () => new Cat("Мурзик");

        // Ковариантность: присваиваем делегаты, возвращающие Dog и Cat, делегату Func<Animal>
        Func<Animal> animalCreator;

        animalCreator = createDog; // Dog → Animal
        Animal animal1 = animalCreator();
        animal1.MakeSound();

        animalCreator = createCat; // Cat → Animal
        Animal animal2 = animalCreator();
        animal2.MakeSound();

        Console.WriteLine("\n=== Демонстрация контравариантности ===");

        // Создаем делегаты для действий с животными
        Action<Animal> animalAction = (animal) =>
        {
            Console.Write($"Действие с животным {animal.Name}: ");
            animal.MakeSound();
        };

        Action<Dog> dogAction = (dog) =>
        {
            Console.Write($"Действие с собакой {dog.Name}: ");
            dog.Fetch();
        };

        Action<Cat> catAction = (cat) =>
        {
            Console.Write($"Действие с кошкой {cat.Name}: ");
            cat.Purr();
        };

        // Контравариантность: присваиваем Action<Animal> более специфичным делегатам
        Action<Dog> dogActionFromAnimal = animalAction;
        Action<Cat> catActionFromAnimal = animalAction;

        Dog myDog = new Dog("Бобик");
        Cat myCat = new Cat("Барсик");

        Console.WriteLine("\nИспользуем Action<Animal> как Action<Dog>:");
        dogActionFromAnimal(myDog);

        Console.WriteLine("\nИспользуем Action<Animal> как Action<Cat>:");
        catActionFromAnimal(myCat);

        Console.WriteLine("\n=== Дополнительные примеры ===");

        // Можно также присвоить специфичные действия через общий интерфейс
        Action<Animal> combinedAction = animalAction;
        combinedAction += (animal) =>
        {
            if (animal is Dog d) dogAction(d);
            else if (animal is Cat c) catAction(c);
        };

        Console.WriteLine("\nКомбинированное действие для собаки:");
        combinedAction(myDog);

        Console.WriteLine("\nКомбинированное действие для кошки:");
        combinedAction(myCat);
    }
}