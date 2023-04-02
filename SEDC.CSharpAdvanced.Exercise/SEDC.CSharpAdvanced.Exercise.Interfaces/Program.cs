using SEDC.CSharpAdvanced.Exercise.Interfaces.Interfaces;
using SEDC.CSharpAdvanced.Exercise.Interfaces.Models;

Student student1 = new Student { Id = 1, Name = "John Smith", Username = "johnsmith", Password = "password", Grades = new double[] { 3.2, 4.0, 3.8 } };
Student student2 = new Student { Id = 2, Name = "Eleonora Gorgjieva", Username = "eli", Password = "password", Grades = new double[] { 3.1, 4.2, 5.2 } };

Teacher teacher1 = new Teacher { Id = 101, Name = "Dr. James Smith", Username = "jamessmith", Password = "password", Subject = "Mathematics" };
Teacher teacher2 = new Teacher { Id = 50, Name = "Mr. Eleonora Todorovska", Username = "elitod", Password = "password", Subject = "CSharp" };


IUser[] users = { student1, student2, teacher1, teacher2 };

foreach (var user in users)
{
    user.PrintUser();
}





