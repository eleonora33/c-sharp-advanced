using SEDC.MainHomework.TimeTracking.Models.Models;
using SEDC.MainHomework.TimeTracking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.MainHomework.TimeTracking.BusinessLogic
{
    public class AccountService
    {
        public void AccountManagement(User? currentUser)
        {
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("Account Management");
                Console.WriteLine("1. Change Password");
                Console.WriteLine("2. Change First Name");
                Console.WriteLine("3. Change Last Name");
                Console.WriteLine("4. Deactivate Account");
                Console.WriteLine("5. Go back to the main menu");
                Console.WriteLine();

                Console.Write("Enter your choice: ");
                string option = Console.ReadLine();

                if (currentUser == null)
                {
                    Console.WriteLine("Login first");
                    return;
                }

                switch (option)
                {
                    case "1":
                        ChangePassword(currentUser.Username);
                        break;
                    case "2":
                        ChangeFirstName(currentUser.Username);
                        break;
                    case "3":
                        ChangeLastName(currentUser.Username);
                        break;
                    case "4":
                        DeactivateAccount(currentUser.Username);
                        break;
                    case "5":
                        quit = true;
                        Console.WriteLine("Returning to the main menu...");
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        Console.WriteLine();
                        break;
                }
            }
        }

        public void ChangePassword(string username)
        {
            Console.Write("Enter new password: ");
            string newPassword = Console.ReadLine();

            var user = Database.Users.First(x => x.Username == username);
            user.Password = newPassword;

            Console.WriteLine("Password changed successfully!");
            Console.WriteLine();
        }

        public void ChangeFirstName(string username)
        {
            Console.WriteLine("Enter new first name:");
            string newFirstName = Console.ReadLine();

            var user = Database.Users.First(x => x.Username == username);
            user.FirstName = newFirstName;

            Console.WriteLine("First name changed successfully!");
            Console.WriteLine();
        }

        public void ChangeLastName(string username)
        {
            Console.WriteLine("Enter new last name:");
            string newLastName = Console.ReadLine();

            var user = Database.Users.First(x => x.Username == username);
            user.LastName = newLastName;

            Console.WriteLine("Last name change successfully!");
            Console.WriteLine();
        }

        public void DeactivateAccount(string username)
        {
            var user = Database.Users.First(x => x.Username == username);
            user.IsActive = false;

            Console.WriteLine("Account deactivated successfully!");
            Console.WriteLine();
        }

        public void ActivateAccount(string username)
        {
            var user = Database.Users.First(x => x.Username == username);
            user.IsActive = true;

            Console.WriteLine("Account activated successfully!");
            Console.WriteLine();

        }
    }
}


