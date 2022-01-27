using System.ComponentModel.DataAnnotations;

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
