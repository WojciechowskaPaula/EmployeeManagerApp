using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeManager.Models.ViewModels
{
    public class EmployeeEditVM
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [Required(ErrorMessage = "Zip is Required")]
        [RegularExpression(@"\d{2}-\d{3}$", ErrorMessage = "Invalid Zip")]
        public string ZipCode { get; set; }
        public int ManagerId { get; set; }
        public Position Position { get; set; }
        public List<Project> Projects { get; set; }
    }
}
