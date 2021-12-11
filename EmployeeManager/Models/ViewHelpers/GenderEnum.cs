using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models.ViewHelpers
{
    public enum GenderEnum
    {
        [Display(Name="Female")]
        famale = 1,
        [Display(Name = "Male")]
        male = 2
    }
}
