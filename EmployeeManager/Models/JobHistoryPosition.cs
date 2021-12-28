using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class JobHistoryPosition
    {
        public int JobHistoryId { get; set; }
        public JobHistory JobHistory { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
