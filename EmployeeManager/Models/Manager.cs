using System.Collections.Generic;

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
