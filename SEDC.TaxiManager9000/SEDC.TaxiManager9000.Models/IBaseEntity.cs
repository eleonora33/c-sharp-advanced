using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.TaxiManager9000.Models
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        void PrintInfo();
    }
}
