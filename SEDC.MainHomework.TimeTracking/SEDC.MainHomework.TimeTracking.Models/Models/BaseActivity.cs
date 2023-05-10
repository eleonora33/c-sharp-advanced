using System.Runtime.CompilerServices;

namespace SEDC.MainHomework.TimeTracking.Models.Models
{
    public abstract class BaseActivity
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public TimeSpan TimeDuration => TimeEnd - TimeStart;
        public User User { get; set; }

        public virtual void StartActivity(User user)
        {
            User ??= user ?? throw new Exception("Can not start activity if user is null");

            if (TimeEnd != default)
            {
                throw new Exception("Activity is already finished");
            }

            TimeStart = DateTime.Now;
        }

        public virtual TimeSpan StopActivity()
        {
            if (TimeStart == default)//01.01. e defoltna vrednost na Date Time
            {
                throw new Exception("Activity is not started yet!");
            }

            TimeEnd = DateTime.Now;

            return TimeDuration;
        }
    }
}
