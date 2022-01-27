using EmployeeManager.Models.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class Employee
    {
        public Employee() { }
        public Employee(EmployeeEditVM employeeEditVM)
        {
            this.EmployeeId = employeeEditVM.EmployeeId;
            this.FirstName = employeeEditVM.FirstName;
            this.LastName = employeeEditVM.LastName;
            this.BirthDate = employeeEditVM.BirthDate;
            this.Gender = employeeEditVM.Gender;
            this.City = employeeEditVM.City;
            this.Country = employeeEditVM.Country;
            this.ZipCode = employeeEditVM.ZipCode;
            this.Position = employeeEditVM.Position;
            this.ManagerId = employeeEditVM.ManagerId;
        }
        public Employee(EmployeeAddVM employeeAddVM)
        {
            this.EmployeeId = employeeAddVM.EmployeeId;
            this.FirstName = employeeAddVM.FirstName;
            this.LastName = employeeAddVM.LastName;
            this.BirthDate = employeeAddVM.BirthDate;
            this.Gender = employeeAddVM.Gender;
            this.City = employeeAddVM.City;
            this.Country = employeeAddVM.Country;
            this.ZipCode = employeeAddVM.ZipCode;
            this.Position = employeeAddVM.Position;
            this.ManagerId = employeeAddVM.ManagerId;
        }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string  City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public JobHistory JobHistory { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public Position Position { get; set; }
    }
    
}
