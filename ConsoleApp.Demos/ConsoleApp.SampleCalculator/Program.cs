Console.WriteLine("Welcome to the sample calculator!");

Console.WriteLine("Please select an operation (-1 to exit program)");
Console.WriteLine("Please select an operation: ");
Console.WriteLine("1.Addition");
Console.WriteLine("2.Subtraction");
Console.WriteLine("3.Multiplication");
Console.WriteLine("4.Division");
Console.WriteLine("5.Fibonacci sequence");
int choice = Convert.ToInt32(Console.ReadLine());

while (choice != -1)
{
    Console.Write("Please enter the first number: ");
    int num1 = Convert.ToInt32(Console.ReadLine());

    Console.Write("Please enter the second number: ");
    int num2 = Convert.ToInt32(Console.ReadLine());

    int answer = 0;
    switch (choice)
    {
        case 1:
            answer = num1 + num2;
            break;
        case 2:
            answer = num1 - num2;
            break;
        case 3:
            answer = num1 * num2;
            break;
        case 4:
            answer = num1 / num2;
            break;
        case 5:
            for (int i = num1; i <= num2; i++)
            {
                answer += i;
            }
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }

    Console.WriteLine($"The result is: {answer}");
    Console.WriteLine("Press Enter to continue");
    Console.ReadLine();
    Console.Clear();
    Console.WriteLine("Please select an operation (-1 to exit program)");
    Console.WriteLine("Please select an operation: ");
    Console.WriteLine("1.Addition");
    Console.WriteLine("2.Subtraction");
    Console.WriteLine("3.Multiplication");
    Console.WriteLine("4.Division");
    Console.WriteLine("5.Fibonacci sequence");
    choice = Convert.ToInt32(Console.ReadLine());
}

Console.WriteLine("Thanks for using sample calculator!");