using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SEDC.Homework._11
{
    public static class DataBase
    {
        public static List<Dog> Dogs = new List<Dog>()
        {
            new Dog { Name = "Cezar", Color = "black", Age = 7 },
            new Dog { Name = "Blecky", Color = "brown", Age = 14 },
        };

        public static void PrintAllDogs()
        {
            Console.WriteLine(JsonSerializer.Serialize(Dogs));
        }
    }
}
