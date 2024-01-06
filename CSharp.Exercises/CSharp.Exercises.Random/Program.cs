//Write a C# Sharp program that takes userid and password as input (type string). After 3 wrong attempts, user will be rejected

//class Program
//{
//    static void Main(string[] args)
//    {
//        string username = "";  // prvo se zadava vrednost
//        string password = "";
//        int attempts = 0;     // se zadava kolku pati da dozvoli sistemot da se validira

//        while (attempts < 3)
//        {
//            Console.Write("Enter username: ");
//            username = Console.ReadLine();

//            Console.Write("Enter password: ");
//            password = Console.ReadLine();

//            if (username == "myusername" && password == "mypassword")
//            {
//                Console.WriteLine("Login successful!");
//                return;
//            }
//            else
//            {
//                Console.WriteLine("Login failed. Please try again.");
//                attempts++;
//            }
//        }

//        Console.WriteLine("Too many failed attempts. Login rejected.");
//    }
//}

//Write a C# Sharp program that takes two numbers as input and perform an operation
//    (+,-,*,x,/) on them and displays the result of that operation

//Console.WriteLine("Enter first number");
//int firstNumber = int.Parse(Console.ReadLine());

//Console.WriteLine("Enter operation: +, -, /, * ");
//string operation = Console.ReadLine();

//Console.WriteLine("Eneter second number:");
//int secondNumber = int.Parse(Console.ReadLine());

//int result = 0;

//switch (operation)
//{
//    case "+":
//        result = firstNumber + secondNumber; break;
//    case "-":
//        result = firstNumber - secondNumber; break;
//    case "*":
//        result = firstNumber * secondNumber; break;
//    case "/":
//        result = firstNumber / secondNumber; break;

//    default:
//        Console.WriteLine("Ivalid operation please try again");
//        break;
//}
//Console.WriteLine($"The result of the operation {operation} on {firstNumber} and {secondNumber} is {result}.");

//int voteAge;
//Console.Write("\n\n");
//Console.Write("Detrermine a specific age is eligible for casting the vote:\n");
//Console.Write("----------------------------------------------------------");
//Console.Write("\n\n");


//Console.Write("Input the age of the candidate : ");
//voteAge = Convert.ToInt32(Console.ReadLine());
//if (voteAge < 18)
//{
//    Console.Write("Sorry, You are not eligible to caste your vote.\n");
//    Console.Write("You would be able to caste your vote after {0} year.\n\n", 18 - voteAge);
//}
//else { 
//    Console.Write("Congratulation! You are eligible for casting your vote.\n\n");
//}

//Write a program in C# Sharp to store elements in an array and print it.
//var numbers = new List<int>();


//    int inpoutNumbers = int.Parse(Console.ReadLine());
//    numbers.Add(inpoutNumbers);

//foreach (var number in numbers) 
//{
//    Console.WriteLine($"Numbers is: {number}");
//}

//List<int> numbers = new List<int>();

//Console.WriteLine("Enter some numbers (press enter to finish):");

//while (true)
//{
//    string input = Console.ReadLine();

//    if (input == "")
//    {
//        break;
//    }

//    int number = int.Parse(input);
//    numbers.Add(number);
//}

//Console.WriteLine("\nThe numbers you entered are:");

//foreach (int number in numbers)
//{
//    Console.Write(number + " ");
//}








