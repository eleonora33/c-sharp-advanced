namespace SEDC.MainHomework.TimeTracking.Models.Models
{
    public class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; } = true;


        public void PrintInfo()
        {
            Console.WriteLine($"{FirstName} {LastName} {Age} {Username}");
        }
    }
}