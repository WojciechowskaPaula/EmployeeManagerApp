using EmployeeManager.Data;
using EmployeeManager.Interfaces;
using EmployeeManager.Models;
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
    }

    
}
