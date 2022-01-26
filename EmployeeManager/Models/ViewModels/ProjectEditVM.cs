using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models.ViewModels
{
    public class ProjectEditVM : Project
    {
        public List<Employee> Employees { get; set; }
    }

    public class ProjectEditVMValidator : AbstractValidator<ProjectEditVM>
    {
        public ProjectEditVMValidator()
        {
            Include(new ProjectValidator());
        }
    }
}
