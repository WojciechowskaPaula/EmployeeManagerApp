using FluentValidation;
using System.Collections.Generic;

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