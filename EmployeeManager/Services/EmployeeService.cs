using EmployeeManager.Data;
using EmployeeManager.Interfaces;
using EmployeeManager.Models;
using EmployeeManager.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManager.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = _dbContext.Employees.ToList();
            return employees;
        }

        public EmployeeDetailVM GetEmployeeDetail(int id)
        {
            var detail = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            var vm = new EmployeeDetailVM();
            vm.EmployeeId = detail.EmployeeId;
            vm.FirstName = detail.FirstName;
            vm.LastName = detail.LastName;
            vm.BirthDate = detail.BirthDate.ToString("d");
            vm.Gender = detail.Gender;
            vm.City = detail.City;
            vm.Country = detail.Country;
            vm.ZipCode = detail.ZipCode;
            vm.ManagerId = detail.ManagerId;
            vm.Position = detail.Position;
            return vm;
        }
        
        public Employee AddNewEmployee(Employee employee)
        {
            var newEmployee = new Employee();
            newEmployee.EmployeeId = employee.EmployeeId;
            newEmployee.FirstName = employee.FirstName;
            newEmployee.LastName = employee.LastName;
            newEmployee.BirthDate = employee.BirthDate;
            newEmployee.Gender = employee.Gender;
            newEmployee.City = employee.City;
            newEmployee.Country = employee.Country;
            newEmployee.ZipCode = employee.ZipCode;
            newEmployee.ManagerId = employee.ManagerId;
            newEmployee.Position = employee.Position;
            _dbContext.Employees.Add(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }

        public Employee GetEmployeeById(int id)
        {
           var employee =  _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            return employee;
        }
        public Employee UpdateEmployee(Employee employee)
        {
            var oldEmployee = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
           
            oldEmployee.EmployeeId = employee.EmployeeId;
            oldEmployee.FirstName = employee.FirstName;
            oldEmployee.LastName = employee.LastName;
            oldEmployee.BirthDate = employee.BirthDate;
            oldEmployee.Gender = employee.Gender;
            oldEmployee.City = employee.City;
            oldEmployee.Country = employee.Country;
            oldEmployee.ZipCode = employee.ZipCode;
            oldEmployee.ManagerId = employee.ManagerId;
            oldEmployee.Position = employee.Position;
            _dbContext.SaveChanges();
            return employee;
        }
       
        public void Delete(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }
    }

    
}
