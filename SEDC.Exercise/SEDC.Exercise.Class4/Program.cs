using System;
using System.Collections.Generic;

class Dog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }

    public void Bark()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Bark Bark");
        Console.ResetColor();
    }

    public static bool Validate(Dog dog)
    {
        if (dog.Id < 0 || string.IsNullOrEmpty(dog.Name) || dog.Name.Length < 2 || string.IsNullOrEmpty(dog.Color))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

static class DogShelter
{
    private static List<Dog> dogs = new List<Dog>();

    public static void AddDog(Dog dog)
    {
        if (Dog.Validate(dog))
        {
            dogs.Add(dog);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid dog: {dog.Id} {dog.Name} {dog.Color}");
            Console.ResetColor();
        }
    }

    public static void PrintAll()
    {
        foreach (Dog dog in dogs)
        {
            Console.WriteLine($"Dog {dog.Id}: {dog.Name} ({dog.Color})");
        }
    }
}

class Program
{
    static void Main()
    {
        Dog dog1 = new Dog { Id = 1, Name = "Cezar", Color = "Brown" };
        Dog.Validate(dog1);
        DogShelter.AddDog(dog1);

        Dog dog2 = new Dog { Id = -2, Name = "Mafi", Color = "Black" };
        Dog.Validate(dog2);
        DogShelter.AddDog(dog2);

        Dog dog3 = new Dog { Id = 3, Name = "Sarko", Color = "White" };
        Dog.Validate(dog3);
        DogShelter.AddDog(dog3);
       
        DogShelter.PrintAll();
    }
}

