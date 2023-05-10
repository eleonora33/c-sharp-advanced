using SEDC.MainHomework.TimeTracking.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.MainHomework.TimeTracking.Models.Models
{
    public class WorkingActivity : BaseActivity
    {
        public WorkLocation WorkLocation { get; set; }

        public WorkingActivity(WorkLocation workLocation)
        {
            WorkLocation = workLocation;
        }

        public override void StartActivity(User user)
        {
            base.StartActivity(user);
        }

        public override TimeSpan StopActivity()
        {
            return base.StopActivity();
        }
    }
}
