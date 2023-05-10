using SEDC.MainHomework.TimeTracking.BusinessLogic;
using SEDC.MainHomework.TimeTracking.Enum;
using SEDC.MainHomework.TimeTracking.Models.Models;
using SEDC.MainHomework.TimeTracking.Repository;
using SEDC.MainHomework.TimeTracking.TextHelper;


User currentUser = null;

while (true)
{
    TextHelper.PrintIntroText();
    MainMenu();
}

static void MainMenu()
{
    var accountService = new AccountService();

    Console.WriteLine(@$"Main menu: 
1.Registration form
2.Log in
3.Track
4.Statistic
5.Account Management
6.Log out");

    string menuOptions = Console.ReadLine();

    if (menuOptions != null)
    {
        if (menuOptions == "1")
        {
            RegisterForm();
        }
        else if (menuOptions == "2")
        {
            LogInStep();
        }
        else if (menuOptions == "3")
        {
            LogInStep();
            TextHelper.OptionsActivityMenu();
            ActivityMenu();
        }
        else if (menuOptions == "4")
        {
            LogInStep();
            StatisticsMenu(AppState.CurrentUser);
        }
        else if (menuOptions == "5")
        {
            LogInStep();
            accountService.AccountManagement(AppState.CurrentUser);

        }
        else if (menuOptions == "6")
        {
            Console.WriteLine("Exit");
            LogOut();
        }
    }
}

static void RegisterForm()
{
    var accountService = new AccountService();

    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Welcome to the registration form!");
        Console.ResetColor();

        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter a username: ");
        string username = Console.ReadLine();

        Console.Write("Enter a password: ");
        string password = Console.ReadLine();

        if (firstName.Length < 2 || lastName.Length < 2 || firstName.Any(char.IsDigit) || lastName.Any(char.IsDigit))
        {
            Console.WriteLine("First Name and Last Name should not be shorter than 2 characters");
            Console.WriteLine("First Name and Last Name should not contain numbers");
            continue;
        }
        if (age < 18 || age > 120)
        {
            Console.WriteLine("Your age is not appropriate for this app");
            continue;
        }
        if (username.Length < 5)
        {
            Console.WriteLine("Username should not be shorter than 5 characters");
            continue;
        }
        if (password.Length < 6)
        {
            Console.WriteLine("Password should not be shorter than 6 characters");
            continue;
        }
        if (!password.Any(char.IsUpper) || !password.Any(char.IsDigit))
        {
            Console.WriteLine("Password must contain one upper letter and one number");
            continue;
        }

        User user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Age = age,
            Username = username,
            Password = password
        };

        Database.Users.Add(user);
        var users = Database.Users.ToList();
        user.PrintInfo();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Registration successful!");
        Console.ResetColor();

        break;
    }
}

static void LogInStep()
{
    if (AppState.CurrentUser != null)
    {
        return;
    }

    int maxAttempts = 3;
    int attempts = 0;
    bool found = false;

    var authentication = new AuthenticationService();

    while (attempts < maxAttempts && !found)
    {
        Console.WriteLine("Please login with your credentials:");

        Console.Write("Username: ");
        string loginUsername = Console.ReadLine();

        Console.Write("Password: ");
        string loginPassword = Console.ReadLine();

        AppState.CurrentUser = authentication.Login(loginUsername, loginPassword);

        if (AppState.CurrentUser != null)
        {
            Console.WriteLine($"Welcome {AppState.CurrentUser.FirstName} {AppState.CurrentUser.LastName}!");
            found = true;

            AccountService accountService = new AccountService();

            if (!AppState.CurrentUser.IsActive)
            {
                TextHelper.PrintAccountNotActive();
                string activateAccountChoice = Console.ReadLine();

                if (activateAccountChoice.ToLower() == "y")
                {
                    accountService.ActivateAccount(AppState.CurrentUser.Username);
                }
                else
                {
                    LogOut();
                }
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid username or password. Please try again.");
            Console.ResetColor();

            attempts++;
        }
    }

    if (!found)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You have exceeded the maximum number of login attempts. Goodbye!");
        Console.ResetColor();

        Environment.Exit(0);
    }
}

static void ActivityMenu()
{
    while (true)
    {
        string option = Console.ReadLine();

        if (option == "1")
        {
            Console.WriteLine(@$"Reading:
{ReadingType.Fiction}
{ReadingType.ProfessionalLiterature}
{ReadingType.BalletLetters}");

            Console.WriteLine("Write the name of activity from the menu reading:");

            string optionForRead = Console.ReadLine();
            TextHelper.StartAndStopActivityMessage();
            ReadActivity(optionForRead);
        }
        else if (option == "2")
        {
            Console.WriteLine(@$"Exercising:
{ExerciseType.General}
{ExerciseType.Running}
{ExerciseType.Sport}");

            Console.WriteLine("Write the name of activity from the menu exercising:");

            string optionForExercise = Console.ReadLine();
            TextHelper.StartAndStopActivityMessage();
            ExerciseActivity(optionForExercise);
        }
        else if (option == "3")
        {
            Console.WriteLine(@$"Working:
{WorkLocation.AtTheOffice}
{WorkLocation.FromHome}");

            Console.WriteLine("Write the name of activity from the menu working:");

            string optionsForWork = Console.ReadLine();
            TextHelper.StartAndStopActivityMessage();
            WorkActivity(optionsForWork);
        }
        else if (option == "4")
        {
            Console.WriteLine($"{AppState.CurrentUser.FirstName} please write the name of the hobby:");
            string optionForOtherHobby = Console.ReadLine();

            var otherHobby = new OtherHobbyActivity(optionForOtherHobby);

            Database.OtherHobbyActivities.Add(otherHobby);
            Database.Save();

            TextHelper.StartAndStopActivityMessage();

            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Start activity {otherHobby.TimeDuration}");
            Console.ResetColor();

            otherHobby.StartActivity(AppState.CurrentUser);

            Console.ReadKey(true);

            var globalStatisticsService = new GlobalStatisticsService();
            TimeSpan duration = globalStatisticsService.StopActivity(otherHobby);
            Database.OtherHobbyActivities.Add(otherHobby);
            Database.Save();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Duration of {optionForOtherHobby} : {duration}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You don`t choose activity try again");
            Console.ResetColor();
        }
        break;
    }
}

static void ReadActivity(string optionForRead)
{
    if (optionForRead == ReadingType.Fiction.ToString() ||
        optionForRead == ReadingType.BalletLetters.ToString() ||
        optionForRead == ReadingType.ProfessionalLiterature.ToString())
    {
        var readingType = (ReadingType)Enum.Parse(typeof(ReadingType), optionForRead);
        var readingActivity = new ReadingActivity(readingType);

        Console.ReadKey();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Start activity {readingActivity.TimeDuration}");
        Console.ResetColor();

        readingActivity.StartActivity(AppState.CurrentUser);

        Console.ReadKey(true);

        var globalStatisticsService = new GlobalStatisticsService();
        TimeSpan duration = globalStatisticsService.StopActivity(readingActivity);

        Database.Readings.Add(readingActivity);
        Database.Save();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(@$"Duration of {optionForRead} reading: {duration}
Total pages: {readingActivity.Pages}");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Invalid read option: {optionForRead}");
        Console.ResetColor();
    }

}

static void ExerciseActivity(string optionForExercise)
{
    if (optionForExercise == ExerciseType.General.ToString() ||
        optionForExercise == ExerciseType.Running.ToString() ||
        optionForExercise == ExerciseType.Sport.ToString())
    {
        var exerciseType = (ExerciseType)Enum.Parse(typeof(ExerciseType), optionForExercise);
        var exercise = new ExercisingActivity(exerciseType);

        Console.ReadKey();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Start activity {exercise.TimeDuration}");
        Console.ResetColor();

        exercise.StartActivity(AppState.CurrentUser);

        Console.ReadKey(true);

        var globalStatisticsService = new GlobalStatisticsService();
        TimeSpan duration = globalStatisticsService.StopActivity(exercise);
        Database.Exercises.Add(exercise);
        Database.Save();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Duration of {exercise.ExerciseType} exercise: {duration}");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Invalid exercise option: {optionForExercise}");
        Console.ResetColor();
    }
}

static void WorkActivity(string optionForWork)
{
    if (optionForWork == WorkLocation.AtTheOffice.ToString() ||
        optionForWork == WorkLocation.FromHome.ToString())
    {
        var workLocation = (WorkLocation)Enum.Parse(typeof(WorkLocation), optionForWork);
        var workActivity = new WorkingActivity(workLocation);

        Console.ReadKey();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Start activity {workActivity.TimeDuration}");
        Console.ResetColor();

        workActivity.StartActivity(AppState.CurrentUser);

        Console.ReadKey(true);
        var globalStatisticsService = new GlobalStatisticsService();
        TimeSpan duration = globalStatisticsService.StopActivity(workActivity);
        Database.WorkingActivities.Add(workActivity);
        Database.Save();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Duration of {optionForWork} working: {duration}");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Invalid exercise option: {optionForWork}");
        Console.ResetColor();
    }
}

static void StatisticsMenu(User? currentUser)
{
    var statisticsService = new StatisticsService();

    while (true)
    {
        Console.WriteLine("Statistics menu:");
        Console.WriteLine("1.Reading");
        Console.WriteLine("2.Exercising");
        Console.WriteLine("3.Working");
        Console.WriteLine("4.Hobbies");
        Console.WriteLine("5.Global");
        Console.WriteLine("6.Main menu");

        int statisticsOption = int.Parse(Console.ReadLine());

        if (statisticsOption == 1)
        {
            statisticsService.PrintReadingStatistics(AppState.CurrentUser.Username);
        }

        if (statisticsOption == 2)
        {
            statisticsService.PrintExercisingStatistics(AppState.CurrentUser.Username);
        }

        if (statisticsOption == 3)
        {
            statisticsService.PrintWorkingStatistics(AppState.CurrentUser.Username);
        }

        if (statisticsOption == 4)
        {
            statisticsService.PrintHobbyStatistics(AppState.CurrentUser.Username);
        }

        if (statisticsOption == 5)
        {
            GlobalStatisticsService.GetGlobalStatistics();
        }

        if (statisticsOption == 6)
        {
            break;
        }
    }
}

static void LogOut()
{
    AppState.CurrentUser = null;
}



