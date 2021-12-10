using EmployeeManager.Interfaces;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            var details = _employeeService.GetEmployeeDetail(id);
            return View(details);
        }
        
        [HttpGet]
        public IActionResult AddEmployeeForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewEmployee(Employee employee)
        {
            var newEmployee = _employeeService.AddNewEmployee(employee);
            return RedirectToAction("Index");
        }
    }
}
