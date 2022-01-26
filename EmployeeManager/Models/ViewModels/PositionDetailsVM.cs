using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models.ViewModels
{
    public class PositionDetailsVM : Position { }
    public class PositionDetailsVMValidator : AbstractValidator<PositionDetailsVM>
    {
        public PositionDetailsVMValidator()
        {
            Include(new PositionValidator());
        }
    }
}
