using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
