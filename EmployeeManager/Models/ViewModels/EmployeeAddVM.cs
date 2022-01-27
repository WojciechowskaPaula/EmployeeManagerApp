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
        public List<ManagerListInfo> Managers { get; set; }
        public Position Position { get; set; }
    }
    public class EmployeeValidator : AbstractValidator<EmployeeAddVM>
    {
        public EmployeeValidator()
        {
            Include(new EmployeeBaseValidator());
        }

    }

}
