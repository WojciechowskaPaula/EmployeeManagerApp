using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class JobHistory
    {
        
        public int JobHistoryId { get; set; }
        public int PositionId { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double Salary { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
