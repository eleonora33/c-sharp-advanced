using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.MainHomework.TimeTracking.Models.Models
{
    public class OtherHobbyActivity : BaseActivity
    {
        public string? NameOfActivity { get; set; }// kako vo userot sto imam napraveno

        public OtherHobbyActivity(string nameOfActivity)
        {
            NameOfActivity = nameOfActivity;
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
