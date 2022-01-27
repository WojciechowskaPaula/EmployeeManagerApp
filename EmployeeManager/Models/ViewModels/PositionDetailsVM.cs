using FluentValidation;

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