using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models.ViewModels
{
    public class PositionAddVM : Position { }
    public class PositionAddVMValidator : AbstractValidator<PositionAddVM>
    {
        public PositionAddVMValidator()
        {
            Include(new PositionValidator());
        }
    }
}
