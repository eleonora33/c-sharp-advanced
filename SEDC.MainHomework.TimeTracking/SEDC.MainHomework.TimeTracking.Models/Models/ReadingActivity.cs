using SEDC.MainHomework.TimeTracking.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.MainHomework.TimeTracking.Models.Models
{
    public class ReadingActivity : BaseActivity
    {
        private const int SECONDS_TO_READ_PAGE = 5;
        public int Pages { get; set; }
        public ReadingType ReadingType { get; set; }

        public ReadingActivity(ReadingType readingType)
        {
            ReadingType = readingType;
        }

        public override void StartActivity(User user)
        {
            base.StartActivity(user);
        }

        public override TimeSpan StopActivity()
        {
            var activityDuration = base.StopActivity();
            Pages = (int)activityDuration.TotalSeconds / SECONDS_TO_READ_PAGE;

            return activityDuration;
        }
    }
}
