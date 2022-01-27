using FluentValidation;
using System.Collections.Generic;

namespace EmployeeManager.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(x => x.ProjectName).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Please enter {PropertyName}")
                .Length(3, 40).WithMessage("{PropertyName} must contain between 3 and 40 characters");
        }
    }
}