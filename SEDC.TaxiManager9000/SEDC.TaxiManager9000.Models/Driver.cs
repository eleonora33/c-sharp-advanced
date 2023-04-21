using SEDC.TaxiManager9000.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SEDC.TaxiManager9000.Models
{
    public class Driver : IBaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAssigned { get; set; }
        public Shift Shift { get; set; }
        public Car Car { get; set; }
        public string License { get; set; }
        public DateTime LicenseExpiryDate { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($" {Id} - {FirstName} {LastName} - {Shift} - {Car?.Model ?? "N/A"}");
        }

        public void DriverStatus() {
            Console.WriteLine($"Driver {FirstName} {LastName} with license {License} expiring on {LicenseExpiryDate}");
        }
    }
}
