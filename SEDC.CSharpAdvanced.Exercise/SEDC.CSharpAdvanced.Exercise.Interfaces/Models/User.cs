using SEDC.CSharpAdvanced.Exercise.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.CSharpAdvanced.Exercise.Interfaces.Models
{
    public abstract class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public abstract void PrintUser();
    }
}
