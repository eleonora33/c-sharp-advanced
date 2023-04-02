using SEDC.CSharpAdvanced.Exercise.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.CSharpAdvanced.Exercise.Interfaces.Models
{

    public class Student : User, IStudent
    {

        public double[] Grades { get; set; }

        public void PrintGrades()
        {
            foreach (var grade in Grades)
            {
                Console.WriteLine($"Grades: {grade}");
            }
        }

        public override void PrintUser()
        {
            Console.WriteLine($"{Id}, {Name}, {Username}");
        }
    }
}
