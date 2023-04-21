using SEDC.TaxiManager9000.Enums;
using SEDC.TaxiManager9000.Models;

namespace SEDC.TaxiManager9000.Repository
{
    public static class Database
    {
        public static List<User> Users { get; set; } = new List<User>
        {
            new User { Id = 1, Username = "admin", Password = "admin123",Role = Role.Administrator },
            new User { Id = 2, Username = "manager", Password = "manager123", Role = Role.Manager },
            new User { Id = 3, Username = "maint", Password = "maint123", Role = Role.Maintenance }
        };

        public static List<Car> Cars { get; set; } = new List<Car>
        {
            new Car { Id = 1, Model = "Toyota", LicensePlate = "SK-3201-AR",AssignedDrivers = new List<Driver>(),LicensePlateExpiryDate = DateTime.Now.AddDays(5), TotalShifts = 12,ShiftsCovered = 10, IsAvailable = true },
            new Car { Id = 2, Model = "Honda", LicensePlate = "SK-5264-AM", AssignedDrivers = new List<Driver>(),LicensePlateExpiryDate = DateTime.Now.AddDays(150), TotalShifts = 10, ShiftsCovered = 5, IsAvailable = true },
            new Car { Id = 3, Model = "Opel", LicensePlate = "SK-5248-AE",AssignedDrivers = new List<Driver>(),LicensePlateExpiryDate = DateTime.Now.AddDays(-10), TotalShifts = 8, ShiftsCovered = 6, IsAvailable = true}
        };

        public static List<Driver> Drivers { get; set; } = new List<Driver>
    {       new Driver { Id = 1, FirstName = "Tose", LastName = "Todorovski",Car = Cars[0],Shift = Shift.Afternoon, License = "00524", LicenseExpiryDate = DateTime.Now.AddDays(130),IsAssigned = false},
            new Driver{ Id = 2, FirstName = "Eli", LastName = "Gjorgjieva",Car = Cars[1], Shift = Shift.Morning, License = "005111", LicenseExpiryDate = DateTime.Now.AddDays(60), IsAssigned = false},
            new Driver{Id = 3, FirstName = "Vlado", LastName = "Gjorgjiev",Car = Cars[2], Shift = Shift.Evening, License = "125424",LicenseExpiryDate= DateTime.Now.AddDays(-10), IsAssigned = false},
};
    }
}
