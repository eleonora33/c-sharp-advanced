using Newtonsoft.Json;
using SEDC.Homework._11;

while (true)
{
    Console.WriteLine("Please enter your dog name, age and color");

    Console.WriteLine("Please enter name of Dog");
    string nameOfDog = Console.ReadLine();

    Console.WriteLine("Please enter color of Dog");
    string color = Console.ReadLine();

    Console.WriteLine("Please enter age of Dog");
    int ageOfDog = int.Parse(Console.ReadLine());

    Dog dogs = new Dog
    {
        Name = nameOfDog,
        Color = color,
        Age = ageOfDog,
    };

    DataBase.Dogs.Add(dogs);
    DataBase.PrintAllDogs();

    string dogSerialized = JsonConvert.SerializeObject(dogs);

    string filePath = "C:\\Projects\\c-sharp-advanced\\SEDC.Homework.11.SerializeAndDeserialize\\SEDC.Homework.11.SerializeAndDeserialize\\TextFileInfo.txt";

    using (StreamWriter sw = new StreamWriter(filePath, true))
    {
        sw.WriteLine(dogSerialized);
    }

    using (StreamReader sr = new StreamReader(filePath))
    {
        string firstLine = sr.ReadLine();
        string secondLine = sr.ReadLine();
        string restContent = sr.ReadToEnd();
        Console.WriteLine($"First Line:{firstLine}");
        Console.WriteLine($"Second Line:{secondLine}");
        Console.WriteLine($"Rest of content:{restContent}");
    }

    Console.ReadKey(true);
    break;
}


