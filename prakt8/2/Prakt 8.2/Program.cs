using System;
using System.Collections.Generic;

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

public class Dog : Animal
{
    public Dog(string name) : base(name) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Woof!");
    }

    public void Fetch()
    {
        Console.WriteLine($"{Name} is fetching the stick");
    }
}

public class Cat : Animal
{
    public Cat(string name) : base(name) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Meow!");
    }

    public void Purr()
    {
        Console.WriteLine($"{Name} is purring");
    }
}

public class Zoo
{
    private List<Animal> animals = new List<Animal>();

    public void AddAnimal<T>(T animal, Action<T> addAction) where T : Animal
    {
        addAction(animal);
        animals.Add(animal);
        Console.WriteLine($"Added {animal.GetType().Name}: {animal.Name}");
    }

    public T GetAnimal<T>(Func<T> getFunc) where T : Animal
    {
        T animal = getFunc();
        Console.WriteLine($"Got {animal.GetType().Name}: {animal.Name}");
        return animal;
    }

    public void ProcessAnimal<T>(T animal, Func<T, Animal> processFunc) where T : Animal
    {
        Animal processed = processFunc(animal);
        Console.WriteLine($"Processed {animal.GetType().Name} as {processed.GetType().Name}: {processed.Name}");
    }

    public void ListAnimals()
    {
        Console.WriteLine("\nAnimals in zoo:");
        foreach (var animal in animals)
        {
            Console.WriteLine($"{animal.GetType().Name}: {animal.Name}");
        }
    }
}

class Program
{
    static void Main()
    {
        Zoo zoo = new Zoo();


        Action<Animal> logAnimal = (animal) =>
        {
            Console.WriteLine($"Logging animal: {animal.Name}");
        };

        Action<Dog> logDog = logAnimal;
        zoo.AddAnimal(new Dog("Rex"), logDog);

        Action<Cat> logCat = logAnimal;
        zoo.AddAnimal(new Cat("Whiskers"), logCat);

        Func<Dog> createDog = () => new Dog("Buddy");
        Func<Cat> createCat = () => new Cat("Mittens");

        Func<Animal> getAnimal = createDog;
        Animal animal1 = zoo.GetAnimal(getAnimal);
        animal1.MakeSound();

        getAnimal = createCat;
        Animal animal2 = zoo.GetAnimal(getAnimal);
        animal2.MakeSound();


        Func<Dog, Animal> processDog = (dog) =>
        {
            Console.WriteLine($"Processing dog: {dog.Name}");
            dog.Fetch();
            return dog;
        };

        zoo.ProcessAnimal(new Dog("Max"), processDog);

        Func<Cat, Animal> processCat = (cat) =>
        {
            Console.WriteLine($"Processing cat: {cat.Name}");
            cat.Purr();
            return cat; 
        };

        zoo.ProcessAnimal(new Cat("Luna"), processCat);

        zoo.ListAnimals();
    }
}