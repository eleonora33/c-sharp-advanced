using SEDC.CSharpAdvanced.Exercise.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.CSharpAdvanced.Exercise.Interfaces.Models
{
    public class Teacher : User, ITeacher
    {
        public string Subject { get; set; }

        public void PrintSubject()
        {
            Console.WriteLine($"Subject: {Subject}");
        }

        public override void PrintUser()
        {
            Console.WriteLine($"{Id}, {Name}, {Username}");
        }
    }
}
