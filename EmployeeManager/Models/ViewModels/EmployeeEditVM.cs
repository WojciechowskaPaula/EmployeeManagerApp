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
    public class EmployeeEditVM : EmployeeBaseVM
    {
        public string BirthDate { get; set; }
        public List<ManagerListInfo> Managers { get; set; }
        public Position Position { get; set; }
        public List <Position> Positions { get; set; }
        public List<Project> Projects { get; set; }
    }

    public class EmployeeEditVMValidator : AbstractValidator<EmployeeEditVM>
    {
        public EmployeeEditVMValidator()
        {
            Include(new EmployeeBaseValidator());
        }
        
    }
}
