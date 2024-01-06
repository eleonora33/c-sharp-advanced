//Declare variables
string? firstName = string.Empty;
string lastName = string.Empty;
int age;
int retirementAge = 65;
decimal salary;
char gender = char.MinValue;
bool working = true;

//Prompt the user for input
Console.WriteLine("Please enter your first name: ");
firstName = Console.ReadLine();

Console.WriteLine("Please enter your last name: ");
lastName = Console.ReadLine();

Console.WriteLine("Please enter your age: ");
age = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Please enter your salary: ");
salary = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Please enter your gender (M or F): ");
gender = Convert.ToChar(Console.ReadLine());

Console.WriteLine("Are you working? (true or false): ");
working = Convert.ToBoolean(Console.ReadLine());

//Process the data
int workingYearsRemaining = retirementAge - age;

//Output the results to the user
Console.WriteLine($"Full name: {firstName} {lastName}");
Console.WriteLine($"Age: {age}");
Console.WriteLine($"Your Salary is: {salary}");
Console.WriteLine($"Your Gender is: {gender}");
Console.WriteLine($"Your are Employed: {working}");
Console.WriteLine($"Number od working years remaining: {workingYearsRemaining}");







