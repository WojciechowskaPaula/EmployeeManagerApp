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
            var vm = new EmployeeDetailVM
            {
                EmployeeId = detail.EmployeeId,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                BirthDate = detail.BirthDate.ToString("d"),
                Gender = detail.Gender,
                City = detail.City,
                Country = detail.Country,
                ZipCode = detail.ZipCode,
                ManagerId = detail.ManagerId
            };
            return vm;
        }

        public Employee AddNewEmployee(Employee employee)
        {
            var newEmployee = new Employee
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                Gender = employee.Gender,
                City = employee.City,
                Country = employee.Country,
                ZipCode = employee.ZipCode,
                ManagerId = employee.ManagerId,
                Position = employee.Position
            };
            _dbContext.Employees.Add(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var oldEmployee = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
            if (oldEmployee.Position != employee.Position)
            {
                var employeePosition = _dbContext.JobHistories.Where(x => x.EmployeeId == employee.EmployeeId).FirstOrDefault();
                var oldPosition = _dbContext.JobHistoryPosition.Where(x => x.JobHistoryId == oldEmployee.JobHistory.JobHistoryId).FirstOrDefault();
                _dbContext.JobHistoryPosition.Remove(oldPosition);
                JobHistoryPosition jobHistoryPosition = new JobHistoryPosition();
                jobHistoryPosition.JobHistoryId = employeePosition.JobHistoryId;
                var positionId = int.Parse(employee.Position.PositionName);
                jobHistoryPosition.PositionId = positionId;
                _dbContext.JobHistoryPosition.Add(jobHistoryPosition);
                _dbContext.SaveChanges();
            }
            oldEmployee.EmployeeId = employee.EmployeeId;
            oldEmployee.FirstName = employee.FirstName;
            oldEmployee.LastName = employee.LastName;
            oldEmployee.BirthDate = employee.BirthDate;
            oldEmployee.Gender = employee.Gender;
            oldEmployee.City = employee.City;
            oldEmployee.Country = employee.Country;
            oldEmployee.ZipCode = employee.ZipCode;
            oldEmployee.ManagerId = employee.ManagerId;
            _dbContext.SaveChanges();

            return employee;
        }

        public void Delete(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }

        public EmployeeEditVM GetEmployeeByIdForEdit(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            var employeeEditVm = new EmployeeEditVM
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                Gender = employee.Gender,
                City = employee.City,
                Country = employee.Country,
                ZipCode = employee.ZipCode,
                ManagerId = employee.ManagerId,
                Position = _dbContext.JobHistoryPosition.Where(x => x.JobHistory.EmployeeId == id).Select(x => x.Position).FirstOrDefault()
            };
            return employeeEditVm;
        }
    }
}