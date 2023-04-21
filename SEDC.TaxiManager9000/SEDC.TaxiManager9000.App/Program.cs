using SEDC.TaxiManager.BusinessLogic;
using SEDC.TaxiManager9000.Enums;
using SEDC.TaxiManager9000.Models;
using SEDC.TaxiManager9000.Repository;
using SEDC.TaxiManager9000.TextHelper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Collections.Generic;

while (true)
{
    MainMenu();
}

static void MainMenu()
{
    var authenticationService = new AuthenticationService();
    TextHelper.LogInMenu();
    
    Console.WriteLine("Enter user name:");
    string username = Console.ReadLine();

    Console.WriteLine("Enter password:");
    string password = Console.ReadLine();

    Console.WriteLine("Enter new password:");
    string newPassword = Console.ReadLine();

    var user = authenticationService.Login(username, password);

    User updateUserPass = authenticationService.ChangePassword(user, password, newPassword);

    if (updateUserPass == null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Password change unsuccessful. Please try again");
        Console.ResetColor();
        MainMenu();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Successful change password!");
        Console.ResetColor();
    }

    if (user != null)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Successful Login!Welcome [{user.Role}] user!");
        Console.ResetColor();

        if (user.Role == Role.Administrator)
        {
            AdminMenu();
        }
        else if (user.Role == Role.Maintenance)
        {
            MaintenanceMenu();
        }
        else if (user.Role == Role.Manager)
        {
            ManagerMenu();

        }
        else
        {
            MainMenu();
        }
        return;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Login unsuccessful. Please try again");
        Console.ResetColor();
    }
}

static void AdminMenu()
{
    while (true)
    {
        Console.WriteLine(@$"1.Add new user
2.Terminate user 
3.Exit
--Choose 1,2 of 3 for Exit--");
        string option = Console.ReadLine();

        if (option == "1")
        {
            Console.WriteLine("Enter new user name:");
            Console.Write("Username (must contain at least 5 characters): ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password:");
            Console.WriteLine("Password must contain at least 5 characters and 1 number");
            string password = Console.ReadLine().ToLower();

            if (username.Length < 5)
            {
                Console.WriteLine("Username must contain at least 5 characters. Please try again.");
                AdminMenu();
                return;
            }
            if (password.Length < 5 && !password.Any(char.IsDigit))
            {
                Console.WriteLine("Password must contain at least 5 characters and 1 number. Please try again.");
                AdminMenu();
                return;
            }
            Console.WriteLine(@$"Select role:
1.Admin
2.Manager
3.Maintenance");
            Console.WriteLine("Enter role:");
            string roleChoice = Console.ReadLine();

            if (roleChoice != null)
            {
                Role role = (Role)int.Parse(roleChoice);

                Console.ForegroundColor = ConsoleColor.Green;
                User newUser = new User
                {
                    Id = Database.Users.Count + 1,
                    Username = username,
                    Password = password,
                    Role = role
                };
                Database.Users.Add(newUser);
                Console.WriteLine($"User {username} has been added.");
                Console.WriteLine($"Successful creation of a {role} user!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice. Please try again.");
                Console.ResetColor();

                AdminMenu();
                return;
            }
        }
        else if (option == "2")
        {
            Console.WriteLine("Terminate user");
            Console.WriteLine("List all users:");
            foreach (User user in Database.Users)
            {
                Console.WriteLine($"Users: {user.Id}, {user.Username}, {user.Password}, {user.Role}");
            }
            Console.WriteLine("Enter username to delete:");
            string searchUser = Console.ReadLine();
            User userToRemove = null;

            foreach (User user in Database.Users)
            {
                if (user.Username == searchUser)
                {
                    userToRemove = user;
                    break;
                }
            }
            if (userToRemove != null)
            {
                Console.WriteLine($"User: {userToRemove.Id}, {userToRemove.Username}, {userToRemove.Password}, {userToRemove.Role}");
                Database.Users.Remove(userToRemove);
                Console.WriteLine($"User {userToRemove.Username} has been deleted");
            }
            else
            {
                Console.WriteLine("User is not found");
            }
        }
        else if (option == "3")
        {
            Console.WriteLine("Exit");
            break;
        }
        else
        {
            MainMenu();
        }
    }
}

static void MaintenanceMenu()
{
    while (true)
    {
        Console.WriteLine(@$"1.List Vehicles
2.List Vehicles License Plates (Statuses)
3.Exit");
        string option = Console.ReadLine();

        if (option == "1")
        {
            foreach (var car in Database.Cars)
            {
                car.PrintInfo();
            }
        }
        else if (option == "2")
        {
            foreach (var vehicle in Database.Cars)
            {
                if (vehicle.LicensePlateExpiryDate < DateTime.Now)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"This vehicle's license plate is expired - {vehicle.LicensePlateExpiryDate}");
                    Console.ResetColor();
                }
                else if (vehicle.LicensePlateExpiryDate > DateTime.Now.AddMonths(3))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"This vehicle's license plate expired for 3 months - {vehicle.LicensePlateExpiryDate}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"This vehicle's license plate is still valid. -  {vehicle.LicensePlateExpiryDate}");
                    Console.ResetColor();
                }
            }
        }
        else if (option == "3")
        {
            Console.WriteLine("Exit");
            break;
        }
        else
        {
            MainMenu();
        }
    }
}

static void ManagerMenu()
{
    while (true)
    {
        Console.WriteLine($@"1.List Drivers
2.List Driver Licenses (Statuses)
3.Driver Manager
4.Exit");
        string option = Console.ReadLine();
        if (option == "1")
        {
            foreach (var drivers in Database.Drivers)
            {
                drivers.PrintInfo();
            }
        }
        else if (option == "2")
        {
            foreach (var drivers in Database.Drivers)
            {
                if (drivers.LicenseExpiryDate < DateTime.Now)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    drivers.DriverStatus();
                    Console.ResetColor();
                }
                else if (drivers.LicenseExpiryDate > DateTime.Now.AddMonths(3))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    drivers.DriverStatus();
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    drivers.DriverStatus();
                    Console.ResetColor();
                }
            }
        }
        else if (option == "3")
        {
            Console.WriteLine("List of all unassigned drivers:");

            var unassignedDrivers = Database.Drivers.Where(d => !d.IsAssigned);
            foreach (var drivers in unassignedDrivers)
            {
                Console.WriteLine(drivers.FirstName + " " + drivers.LastName);
            }

            Console.WriteLine("Choose one of the drivers that are provided:");
            string chosenDriverName = Console.ReadLine();

            var chosenDriver = Database.Drivers.FirstOrDefault(x => x.FirstName == chosenDriverName);

            if (chosenDriver != null)
            {
                chosenDriver.IsAssigned = true;
                Console.WriteLine("Driver assigned successfully.");
            }
            else { Console.WriteLine("Driver not found."); }

            Console.WriteLine("Pick a shift:");
            Console.WriteLine(@$"1.{Shift.Morning}
2.{Shift.Afternoon}
3.{Shift.Evening}");

            int shiftChoice = int.Parse(Console.ReadLine());
            Shift shift = (Shift)shiftChoice;

            Console.WriteLine("Available cars:");
            foreach (var cars in Database.Cars.Where(c => c.IsAvailable && !c.AssignedDrivers.Any(d => d.Shift == shift) && c.LicensePlateExpiryDate > DateTime.Now))
            {
                Console.WriteLine($"{cars.Id}: {cars.Model} ({cars.LicensePlate})");
            }

            int carId = int.Parse(Console.ReadLine());
            var car = Database.Cars.FirstOrDefault(c => c.Id == carId);

            Console.WriteLine("Assigned drivers:");
            foreach (var drivers in Database.Drivers.Where(d => d.IsAssigned))
            {
                Console.WriteLine($"{drivers.Id}: {drivers.FirstName} {drivers.LastName} ({drivers.Car.Model} - {drivers.Shift})");
            }
        }
        else if (option == "4")
        {
            Console.WriteLine("Exit");
            break;
        }
        else
        {
            MainMenu();
        }
    }
}



