using System.Reflection.Metadata;
using System.Security.Principal;

namespace SEDC.TaxiManager9000.TextHelper
{
    public static class TextHelper
    {
        public static void LogInMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Login Menu");
            Console.WriteLine("Taxi Manager 9000");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Log in:");

        }
    }
}