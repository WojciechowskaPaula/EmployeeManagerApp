using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public int RoomNumber { get; set; }
        public int EmployeeId { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
