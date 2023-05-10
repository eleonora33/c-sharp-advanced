using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.MainHomework.TimeTracking.Models.Models
{
    public class GlobalStatistics
    {
        public User User { get; set; }
        public Dictionary<string, double> Statistics { get; set; } = new Dictionary<string, double>();
    }
}
