using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models.ViewModels
{
    public class ManagerEditVM
    {
        public int ManagerId { get; set; }
        public int RoomNumber { get; set; }
        public int EmployeeId { get; set; }
        public List<SelectListItem> Employees { get; set; }
    }
    public class ManagerValidator : AbstractValidator<ManagerEditVM>
    {
        public ManagerValidator()
        {
            RuleFor(x => x.RoomNumber).NotNull().WithMessage("Please enter {PropertyName}")
                .GreaterThan(0).WithMessage("Please enter correct {PropertyName}");
        }
    }
}
