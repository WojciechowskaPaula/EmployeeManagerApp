using System.Collections.Generic;

namespace EmployeeManager.Models
{
    public class JobHistory
    {
        public int JobHistoryId { get; set; }
        ICollection <Position> Positions { get; set; }
        public double Salary { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
