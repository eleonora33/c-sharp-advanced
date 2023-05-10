using SEDC.MainHomework.TimeTracking.Models;
using SEDC.MainHomework.TimeTracking.Models.Models;
using SEDC.MainHomework.TimeTracking.Repository;

namespace SEDC.MainHomework.TimeTracking.BusinessLogic
{
    public class GlobalStatisticsService
    {
        public static void GetGlobalStatistics()
        {
            var globalStatistics = Database.GlobalStatistics.FirstOrDefault(gs => gs.User.Username == AppState.CurrentUser.Username);

            if (globalStatistics == null)
            {
                Console.WriteLine($"There is no activity for user: {AppState.CurrentUser.Username} yet!");
            }
            else
            {
                double totalSecondsOfAllActivities = globalStatistics.Statistics.Values.Sum();
                var totalHoursOfAllActivities = totalSecondsOfAllActivities / 3600;
                var favoriteActivityType = globalStatistics.Statistics.MaxBy(kvp => kvp.Value).Key;

                Console.WriteLine(@$"Total hours of activities for user {globalStatistics.User.FirstName} {globalStatistics.User.LastName} is: {totalHoursOfAllActivities} hours
Favorite activity: {favoriteActivityType}");
            }
        }

        public TimeSpan StopActivity<T>(T activity)
            where T : BaseActivity
        {
            var timeDuration = activity.StopActivity();

            AddStatistics(timeDuration.Seconds, activity.GetType().Name);

            return timeDuration;
        }

        private static void AddStatistics(double seconds, string activityType)
        {
            var userGlobalStatistics = Database.GlobalStatistics.FirstOrDefault(gs => gs.User.Username == AppState.CurrentUser.Username);

            if (userGlobalStatistics != null)
            {
                var addSuccess = userGlobalStatistics.Statistics.TryAdd(activityType, seconds);
                if (!addSuccess)
                {
                    userGlobalStatistics.Statistics[activityType] += seconds;
                }
            }
            else
            {
                var globalStatistic = new GlobalStatistics { User = AppState.CurrentUser };
                globalStatistic.Statistics.Add(activityType, seconds);
                Database.GlobalStatistics.Add(globalStatistic);
            }
        }
    }
}
