using EmployeeManager.Models;
using EmployeeManager.Models.ViewModels;
using System.Collections.Generic;

namespace EmployeeManager.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        EmployeeDetailVM GetEmployeeDetail(int id);
        Employee AddNewEmployee(Employee employee);
        Employee GetEmployeeById(int id);
        Employee UpdateEmployee(Employee employee);
        void Delete(int id);
        EmployeeEditVM GetEmployeeByIdForEdit(int id);
    }
}