using FluentValidation;

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
