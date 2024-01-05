// See https://aka.ms/new-console-template for more information

string name = "Eleonora Todorovska";

Console.WriteLine(name);
Console.WriteLine($"I am {name}");
Console.WriteLine($"They call me {name}"); //interpolation
Console.WriteLine("I am" + name); // concatenation
Console.WriteLine("I was given the name {0}", name); //formatted string

int age = 35;
int retirementYearsLeft = 29;
int retirementAge = age + retirementYearsLeft;
Console.WriteLine("My age is: " + age);
Console.WriteLine("My retirement age is: " + retirementAge);

bool isRetired = false;
Console.WriteLine("Am I retired? " +  isRetired);




