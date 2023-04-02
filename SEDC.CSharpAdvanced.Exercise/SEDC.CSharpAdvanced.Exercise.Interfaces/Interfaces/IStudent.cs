using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.CSharpAdvanced.Exercise.Interfaces.Interfaces
{
    public interface IStudent
    {
        double[] Grades { get; set; }
        void PrintGrades();
    }
}
