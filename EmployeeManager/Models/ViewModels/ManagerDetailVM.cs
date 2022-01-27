using System.Collections.Generic;

namespace EmployeeManager.Models.ViewModels
{
    public class ManagerDetailVM
    {
        public int ManagerId { get; set; }
        public int RoomNumber { get; set; }
        public int EmployeeId { get; set; }
        public List<Employee> Employees { get; set; }
    }
}