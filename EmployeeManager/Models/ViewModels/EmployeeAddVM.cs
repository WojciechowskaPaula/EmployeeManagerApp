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
    public class EmployeeAddVM
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        //[Required(ErrorMessage = "Zip is Required")]
        //[RegularExpression(@"\d{2}-\d{3}$", ErrorMessage = "Invalid Zip")]
        public string ZipCode { get; set; }
        public int ManagerId { get; set; }
        public List<ManagerListInfo> Managers { get; set; }
        public Position Position { get; set; }
    }
    public class EmployeeValidator : AbstractValidator<EmployeeAddVM>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter {PropertyName}")
                .Length(3, 20).WithMessage("{PropertyName} must contain between 3 and 20 characters");
            RuleFor(x => x.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter {PropertyName}")
                .Length(3, 30).WithMessage("{PropertyName} must contain between 3 and 50 characters")
                .NotEqual(x => x.FirstName).WithMessage("{PropertyName} must be different from the {ComparisonValue}");
            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .Must(BeOver18).WithMessage("Invalid BirthDate");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Please enter {PropertyName}");
            RuleFor(x => x.City).NotEmpty().WithMessage("Please enter {PropertyName}")
                .MaximumLength(255).WithMessage("Field can contain a maximum of 255 characters");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Please enter {PropertyName}");
            RuleFor(x => x.ZipCode).NotNull().Must((x, y) => IsValidZipCode(x)).WithMessage("Invalid ZipCode");
        }

        private bool IsValidZipCode(EmployeeAddVM employee)
        {
            var regexPL = new Regex("^\\d{2}[- ]{0,1}\\d{3}$");
            var regexJP = new Regex("^\\d{7}\\s\\(\\d{3}-\\d{4}\\)$");

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

        private bool BeOver18(DateTime dateOfBirth)
        {
            var dateNow = DateTime.Today;
            var years = dateNow.Year - dateOfBirth.Year;
            if(dateNow.DayOfYear <= dateOfBirth.DayOfYear)
            {
                years = years - 1;
            }
            return years >= 18;
        }
        

    }

}
