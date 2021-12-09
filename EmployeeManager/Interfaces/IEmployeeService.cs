using EmployeeManager.Models;
using EmployeeManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        EmployeeDetailVM GetEmployeeDetail(int id);
    }
}
