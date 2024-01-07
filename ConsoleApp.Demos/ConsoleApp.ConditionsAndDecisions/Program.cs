Console.WriteLine("Please enter student grade: ");
int grade = Convert.ToInt32(Console.ReadLine());

if(grade > 50)
{
    Console.WriteLine("Student has passed");
}
else
{
    Console.WriteLine("Student has failed");
    Console.WriteLine("please recommend student to student affair`s office");
}

/*
 * A: 86-100
 * B: 75-84
 * C: 65-74
 * C-:50-64
 * F:less then 50
 */

if(grade < 0 || grade > 100)
{
    Console.WriteLine("Invalid value entered");
}
else if(grade < 50)
{
    Console.WriteLine("Student has failed - F");
}
else if(grade >= 50 && grade <= 64)
{
    Console.WriteLine("C-");
}
else if (grade >= 65 && grade <= 74)
{
    Console.WriteLine("C");
}
else if (grade >= 75 && grade <= 84)
{
    Console.WriteLine("B");
}
else if(grade >= 85 && grade <= 100)
{
    Console.WriteLine("A - Good job");
}

int gradeAfterBonus = grade >= 0 && grade <= 100 ? grade + 10 : 0;
Console.WriteLine($"Grade after bonus: {gradeAfterBonus}");

string passStatus = grade < 50 ? "Fail" : "Pass";
Console.WriteLine($"Student status is: {passStatus}");

Console.WriteLine("Please enter the day of the week");
int dayOfWeek = Convert.ToInt32(Console.ReadLine());
switch (dayOfWeek)
{
    case 1:
        Console.WriteLine("Sunday");
        break;
    case 2: Console.WriteLine("Monday");
        break;
    case 3: Console.WriteLine("Tuesday");
        break;
    case 4: Console.WriteLine("Wednesday");
        break;
    case 5: Console.WriteLine("Thursday");
        break;
    case 6: Console.WriteLine("Friday");
        break;
    case 7: Console.WriteLine("Saturday");
        break;
    default:
        Console.WriteLine("Invalid day number entered!!!");
        break;
}

Console.WriteLine("Thank you for using this program");
