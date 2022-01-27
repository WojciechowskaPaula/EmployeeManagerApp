using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeManager.Models.ViewModels
{
    public class EmployeeBaseVM
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int ManagerId { get; set; }
    }
    public class EmployeeBaseValidator : AbstractValidator<EmployeeBaseVM>
    {
        public EmployeeBaseValidator()
        {
            RuleFor(x => x.FirstName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter {PropertyName}")
                .Length(3, 20).WithMessage("{PropertyName} must contain between 3 and 20 characters");
            RuleFor(x => x.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter {PropertyName}")
                .Length(3, 30).WithMessage("{PropertyName} must contain between 3 and 50 characters")
                .NotEqual(x => x.FirstName).WithMessage("{PropertyName} must be different from the {ComparisonValue}");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Please enter {PropertyName}");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Please enter {PropertyName}");
            RuleFor(x => x.City).NotEmpty().WithMessage("Please enter {PropertyName}")
                .MaximumLength(255).WithMessage("Field can contain a maximum of 255 characters");
            RuleFor(x => x.ZipCode).Cascade(CascadeMode.Stop).NotNull().WithMessage("Please enter {PropertyName}")
                .Must((x, y) => IsValidZipCode(x)).WithMessage("Invalid ZipCode");
        }
        private bool IsValidZipCode(EmployeeBaseVM employee)
        {
            var regexPL = new Regex("^\\d{2}[- ]{0,1}\\d{3}$");
            var regexJP = new Regex("^\\d{3}-\\d{4}$");

            if (employee.Country == "Poland")
            {
                return regexPL.IsMatch(employee.ZipCode);
            }
            else if (employee.Country == "Japan")
            {
                return regexJP.IsMatch(employee.ZipCode);
            }
            return false;
        }
        public bool BeOver18(DateTime dateOfBirth)
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
