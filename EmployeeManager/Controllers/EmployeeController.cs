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
        private readonly IProjectService _projectService;

        public EmployeeController(IEmployeeService employeeService, IProjectService projectService)
        {
            _employeeService = employeeService;
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var details = _employeeService.GetEmployeeDetail(id);
            var employeeProject = _projectService.GetProjectByEmployeeId(id);
            details.Projects = employeeProject;
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

        [HttpGet]
        public IActionResult EditEmployeeForm(int id)
        {
            var edit = _employeeService.GetEmployeeByIdForEdit(id);
            edit.Projects = _projectService.GetProjectByEmployeeId(id);
            return View(edit);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            var update = _employeeService.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public IActionResult DeleteAndConfirm(int id)
        {
            var employeeToDelete = _employeeService.GetEmployeeById(id);
            return View(employeeToDelete);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
             _employeeService.Delete(id);
           
            return RedirectToAction("Index");
        }
    }
}
