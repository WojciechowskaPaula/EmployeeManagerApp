using EmployeeManager.Interfaces;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IManagerService _managerService;

        public EmployeeController(IEmployeeService employeeService, IProjectService projectService, IManagerService managerService)
        {
            _employeeService = employeeService;
            _projectService = projectService;
            _managerService = managerService;
            
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
            var employeeProject = _projectService.GetProjectByEmployeeId(id);
            var details = _employeeService.GetEmployeeDetail(id);
            
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
            edit.Managers = new List<ManagerListInfo>();
            var listOfManagers = _managerService.GetListOfManagers();
            foreach (var item in listOfManagers)
            {
                var employee = _employeeService.GetEmployeeById(item.EmployeeId);
                ManagerListInfo managerListInfo = new ManagerListInfo();
                managerListInfo.EmployeeId = item.EmployeeId;
                managerListInfo.FullName = $"{employee.FirstName} {employee.LastName}";
                edit.Managers.Add(managerListInfo);
            }
            
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
