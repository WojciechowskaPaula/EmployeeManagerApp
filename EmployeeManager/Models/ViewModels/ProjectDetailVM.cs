using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models.ViewModels
{
    public class ProjectDetailVM
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
