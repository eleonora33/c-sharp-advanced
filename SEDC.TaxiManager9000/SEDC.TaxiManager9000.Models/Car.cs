using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.TaxiManager9000.Models
{
    public class Car : IBaseEntity
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public DateTime LicensePlateExpiryDate { get; set; }
        public List<Driver> AssignedDrivers { get; set; }
        public bool IsAvailable { get; set; }
        public int TotalShifts { get; set; }
        public int ShiftsCovered { get; set; }

        public double ShiftsCoveredPercentage()
        {
            {
                return (int)Math.Floor((double)ShiftsCovered / TotalShifts * 100);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{Id}-{Model}-{LicensePlate}-{ShiftsCoveredPercentage()}%");
        }
    }
}
