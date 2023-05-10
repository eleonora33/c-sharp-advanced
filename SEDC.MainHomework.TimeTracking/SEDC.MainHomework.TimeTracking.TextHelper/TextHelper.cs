namespace SEDC.MainHomework.TimeTracking.TextHelper
{
    public class TextHelper
    {
        public static void PrintIntroText()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Welcome to the Time tracking app ");
            Console.WriteLine();
            Console.ResetColor();
        }
        public static void OptionsActivityMenu()
        {
            Console.WriteLine("Activities Available for Tracking:");
            Console.WriteLine("1.Reading");
            Console.WriteLine("2.Exercising");
            Console.WriteLine("3.Working");
            Console.WriteLine("4.Other Hobbies");
        }

        public static void StartAndStopActivityMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press enter when you start with activity and press enter again when you finished with activity");
            Console.ResetColor();
        }

        public static void PrintAccountNotActive()
        {
            Console.WriteLine("Your account is currently deactivated");
            Console.Write("Do you want to reactivate your account? (Y/N): ");
        }
    }
}