using SEDC.MainHomework.TimeTracking.Models.Models;
using System.Text.Json;

namespace SEDC.MainHomework.TimeTracking.Repository
{
    public static class Database
    {
        public static string exercisePath = "C:\\Projects\\c-sharp-advanced\\SEDC.MainHomework.TimeTracking\\SEDC.MainHomework.TimeTracking.App\\DatabaseFiles\\Exercises.json";
        public static string workingPath = "C:\\Projects\\c-sharp-advanced\\SEDC.MainHomework.TimeTracking\\SEDC.MainHomework.TimeTracking.App\\DatabaseFiles\\Working.json";
        public static string readingPath = "C:\\Projects\\c-sharp-advanced\\SEDC.MainHomework.TimeTracking\\SEDC.MainHomework.TimeTracking.App\\DatabaseFiles\\Readings.json";
        public static string hobbyPAth = "C:\\Projects\\c-sharp-advanced\\SEDC.MainHomework.TimeTracking\\SEDC.MainHomework.TimeTracking.App\\DatabaseFiles\\Hobby.json";
        public static string usersPath = "C:\\Projects\\c-sharp-advanced\\SEDC.MainHomework.TimeTracking\\SEDC.MainHomework.TimeTracking.App\\DatabaseFiles\\Users.json";
        public static List<User> Users { get; set; } = string.IsNullOrEmpty(File.ReadAllText(usersPath))
            ? new List<User>
            {
                new User{FirstName = "Eleonora", LastName = "Todorovska", Age =  39, Username = "eleonora", Password = "Sika23" },
                new User{FirstName = "Eleonora", LastName = "Gjorgjieva", Age = 35, Username = "kalina", Password = "Marjan5" },
                new User{FirstName = "John", LastName = "Doe", Age = 30, Username = "johndoe", Password = "Password123" },
            }
            : JsonSerializer.Deserialize<List<User>>(File.ReadAllText(usersPath));

        public static void PrintAllUsers()
        {
            Console.WriteLine(JsonSerializer.Serialize(Users));
        }

        public static void Save()
        {
            string exercisesJson = JsonSerializer.Serialize(Exercises);
            File.WriteAllText(exercisePath, exercisesJson);

            string workingJson = JsonSerializer.Serialize(WorkingActivities);
            File.WriteAllText(workingPath, workingJson);

            string readingsJson = JsonSerializer.Serialize(Readings);
            File.WriteAllText(readingPath, readingsJson);

            string hobbiesJson = JsonSerializer.Serialize(OtherHobbyActivities);
            File.WriteAllText(hobbyPAth, hobbiesJson);

            string usersJson = JsonSerializer.Serialize(Users);
            File.WriteAllText(usersPath, usersJson);
        }

        public static List<ExercisingActivity> Exercises { get; set; } = string.IsNullOrEmpty(File.ReadAllText(exercisePath))
            ? new List<ExercisingActivity>()
            : JsonSerializer.Deserialize<List<ExercisingActivity>>(File.ReadAllText(exercisePath));
        public static List<ReadingActivity> Readings { get; set; } = string.IsNullOrEmpty(File.ReadAllText(readingPath))
            ? JsonSerializer.Deserialize<List<ReadingActivity>>(File.ReadAllText(readingPath))
            : new List<ReadingActivity>();
        public static List<WorkingActivity> WorkingActivities { get; set; } = string.IsNullOrEmpty(File.ReadAllText(workingPath))
            ? JsonSerializer.Deserialize<List<WorkingActivity>>(File.ReadAllText(workingPath))
            : new List<WorkingActivity>();
        public static List<OtherHobbyActivity> OtherHobbyActivities { get; set; } = string.IsNullOrEmpty(File.ReadAllText(hobbyPAth))
            ? JsonSerializer.Deserialize<List<OtherHobbyActivity>>(File.ReadAllText(hobbyPAth))
            : new List<OtherHobbyActivity>();
        public static List<GlobalStatistics> GlobalStatistics { get; set; } = new List<GlobalStatistics>();
    }
}