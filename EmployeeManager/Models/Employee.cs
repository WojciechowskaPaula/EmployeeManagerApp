using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string  City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public JobHistory JobHistory { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public Position Position { get; set; }
    }
}
