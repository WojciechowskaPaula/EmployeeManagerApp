using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public ICollection<JobHistory> JobHistories { get; set; }
        
    }

    public class PositionValidator : AbstractValidator<Position>
    {
        public PositionValidator()
        {
            RuleFor(x => x.PositionName).Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage(("Please enter {PropertyName}"))
               .Length(3, 40).WithMessage("{PropertyName} must contain between 3 and 40 characters");
        }
    }
}
