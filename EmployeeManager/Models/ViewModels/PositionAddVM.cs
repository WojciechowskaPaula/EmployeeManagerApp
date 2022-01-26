using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models.ViewModels
{
    public class PositionAddVM
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        
    }

    public class PositionValidator : AbstractValidator<PositionAddVM>
    {
        public PositionValidator()
        {
            RuleFor(x => x.PositionName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(("Please enter {PropertyName}"))
                .Length(3, 40).WithMessage("{PropertyName} must contain between 3 and 40 characters");
        }
    }
}
