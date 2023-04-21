using SEDC.TaxiManager9000.Enums;
using SEDC.TaxiManager9000.Models;
using SEDC.TaxiManager9000.Repository;

namespace SEDC.TaxiManager.BusinessLogic
{
    public class AuthenticationService
    {
        public User Login(string username, string password)
        {
            return Database.Users.FirstOrDefault(x => x.Username.ToLower() == username?.ToLower() && x.Password == password);
        }

        public User ChangePassword(User user, string password, string newPassword)
        {
            if (Database.Users.Any(x => x.Password.ToLower() == newPassword?.ToLower() && x.Id != user.Id))
            {
                return null;
            }
            user.Password = newPassword;

            return user;
        }
    }
}