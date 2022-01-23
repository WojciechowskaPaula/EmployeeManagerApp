using EmployeeManager.Models.ViewHelpers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeManager.Models.ViewModels
{
    public class EmployeeAddVM : EmployeeBaseVM
    {
        
        public DateTime BirthDate { get; set; }
        
        public List<ManagerListInfo> Managers { get; set; }
        public Position Position { get; set; }
    }
    public class EmployeeValidator : AbstractValidator<EmployeeAddVM>
    {
        public EmployeeValidator()
        {
            Include(new EmployeeBaseValidator());
            
            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .Must(BeOver18).WithMessage("Invalid BirthDate");
        }

        private bool BeOver18(DateTime dateOfBirth)
        {
            var dateNow = DateTime.Today;
            var years = dateNow.Year - dateOfBirth.Year;
            if (dateNow.DayOfYear <= dateOfBirth.DayOfYear)
            {
                years = years - 1;
            }
            return years >= 18;
        }

    }

}
