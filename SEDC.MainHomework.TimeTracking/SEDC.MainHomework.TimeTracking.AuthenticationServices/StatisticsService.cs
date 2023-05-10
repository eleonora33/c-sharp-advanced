using SEDC.MainHomework.TimeTracking.Enum;
using SEDC.MainHomework.TimeTracking.Repository;

namespace SEDC.MainHomework.TimeTracking.BusinessLogic
{
    public class StatisticsService
    {
        public void PrintReadingStatistics(string username)
        {
            var readingActivities = Database.Readings.Where(r => r.User.Username == username).ToList();
            var totalMinutesOfReading = (double)readingActivities.Sum(r => r.TimeDuration.Seconds) / 60;
            var averageActivity = readingActivities.Average(r => r.TimeDuration.TotalMinutes);
            var totalPages = readingActivities.Sum(r => r.Pages);
            var favoriteTypeOfReading = readingActivities.GroupBy(r => r.ReadingType)
                                      .OrderByDescending(readingActivities => readingActivities.Count())
                                      .Select(readingActivities => readingActivities.Key)
                                      .FirstOrDefault();

            Console.WriteLine($"Total time in minutes: [{Math.Round(totalMinutesOfReading, 2)}]");
            Console.WriteLine($"Average of all activity records (in minutes) is: [{Math.Round(averageActivity, 2)}]");
            Console.WriteLine($"Total number of pages:[{totalPages}]");
            Console.WriteLine($"Favorite type:[{favoriteTypeOfReading}]");
        }

        public void PrintExercisingStatistics(string username)
        {
            var exercisingActivities = Database.Exercises.Where(e => e.User.Username == username).ToList();
            var totalMinutesOfExercising = (double)exercisingActivities.Sum(e => e.TimeDuration.Seconds) / 60;
            var averageActivity = exercisingActivities.Average(e => e.TimeDuration.TotalMinutes);
            var favoriteTypeOfExercising = exercisingActivities.GroupBy(e => e.ExerciseType)
                                    .OrderByDescending(exercisingActivities => exercisingActivities.Sum(e => e.TimeDuration.TotalSeconds))
                                    .Select(exercisingActivities => exercisingActivities.Key)
                                    .FirstOrDefault();

            Console.WriteLine($"Total time in minutes: [{Math.Round(totalMinutesOfExercising, 2)}]");
            Console.WriteLine($"Average of all activity records (in minutes) is: [{Math.Round(averageActivity, 2)}]");
            Console.WriteLine($"Favorite type:[{favoriteTypeOfExercising}]");
        }

        public void PrintWorkingStatistics(string username)
        {
            var workingActivities = Database.WorkingActivities.Where(w => w.User.Username == username).ToList();
            var totalHours = (double)workingActivities.Sum(w => w.TimeDuration.Seconds) / 60;
            var averageActivity = workingActivities.Average(w => w.TimeDuration.TotalMinutes);
            var officeHours = Database.WorkingActivities.Where(o => o.WorkLocation == WorkLocation.AtTheOffice)
                                     .Sum(o => (o.TimeEnd - o.TimeStart).TotalHours);
            var workFromHomeHours = Database.WorkingActivities.Where(w => w.WorkLocation == WorkLocation.FromHome)
                                     .Sum(w => (w.TimeEnd - w.TimeStart).TotalHours);

            Console.WriteLine($"Total time in hours: [{Math.Round(totalHours, 2)}]");
            Console.WriteLine($"Average of all activity records (in minutes) is: [{Math.Round(averageActivity, 2)}]");
            Console.WriteLine($"Office hours:[{officeHours}]");
            Console.WriteLine($"Home hours:[{workFromHomeHours}]");
        }

        public void PrintHobbyStatistics(string username)
        {
            var otherHobbyActivities = Database.OtherHobbyActivities.Where(o => o.User.Username == username);
            var totalHours = (double)otherHobbyActivities.Sum(o => o.TimeDuration.Seconds) / 60;
            var distinctHobbies = otherHobbyActivities.Select(o => o.NameOfActivity).Distinct().ToList();

            //var distinctHobbiesAnotherWAy = new HashSet<string>(otherHobbyActivities.Select(h => h.NameOfActivity));

            Console.WriteLine($"Total time in hours:[{Math.Round(totalHours ,2)}]");

            foreach (var hobbyName in distinctHobbies)
            {
                Console.WriteLine($"List of all hobbies [{hobbyName}]");
            }
        }
    }
}
