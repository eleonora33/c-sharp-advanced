try
{
    Console.Write("Enter your age: ");
    int age = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine($"You are {age} years old. ");
}
catch (Exception)
{
    Console.WriteLine("Your age value was incorrect, please try again.  ");
    //throw;
}
finally
{
    Console.WriteLine("Thank you for using this program");
}
