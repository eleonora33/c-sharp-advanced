
for(int i = 0; i < 10; i++)
{
    Console.WriteLine($"Hello, World! - {i}");
}

Console.WriteLine("Loop Completed!");

//Console.WriteLine("How many times should we print hello world?");
//int userCount = Convert.ToInt32(Console.ReadLine());

//for(int i = 0; i < userCount; i++)
//{
//    Console.WriteLine($"Hello, World! - {i}");
//}

int counter = 0;
while(counter < 10)
{
    Console.WriteLine($"Hello, World! - {counter}");
    counter++;
}

int sum = 0;
int num = 0;
while(num != -1)
{
    Console.WriteLine("Please numbers to be summed up (-1 to stop or exit): ");
    num = Convert.ToInt32(Console.ReadLine());
    if(num != -1)
    {
      sum += num;
    }
}

Console.WriteLine($"Your sum is: {sum}");