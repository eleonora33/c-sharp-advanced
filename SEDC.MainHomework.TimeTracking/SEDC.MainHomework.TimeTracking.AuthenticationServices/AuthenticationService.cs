using SEDC.MainHomework.TimeTracking.Models.Models;
using SEDC.MainHomework.TimeTracking.Repository;

namespace SEDC.MainHomework.TimeTracking.BusinessLogic
{
    public class AuthenticationService
    {
        public User Login(string loginUsername, string loginPassword)
        {
            return Database.Users.FirstOrDefault(x => x.Username.ToLower() == loginUsername?.ToLower() && x.Password == loginPassword);
        }
    }
}