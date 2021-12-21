using EmployeeManager.Interfaces;
using EmployeeManager.Models;
using EmployeeManager.Models.ViewHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IEmployeeService _employeeService;
        
        public ProjectController(IProjectService projectService, IEmployeeService employeeService)
        {
            _projectService = projectService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var projects = _projectService.GetListOfProjects();
            return View(projects);
        }

        [HttpGet]
        public IActionResult AddNewProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProject(Project project)
        {
           var newProject = _projectService.AddNewProject(project);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
           var employeeList = _projectService.GetEmployeeByProjectId(id);
           var details = _projectService.DisplayProjectDetails(id);
            details.Employees = employeeList;
            return View(details);
        }

        [HttpGet]
        public IActionResult DeleteAndConfirm(int projectId)
        {
            var project = _projectService.DisplayProjectDetails(projectId);
            return View(project);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _projectService.DeleteProject(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteFromEmployee(int projectId, int employeeId)
        {
            _projectService.DeleteProjectFromEmployee(projectId, employeeId);
            return RedirectToAction("EditProjectForm",new {id = projectId});
        }
        [HttpGet]
        public IActionResult EditProjectForm(int id)
        {
            var projectVM = _projectService.GetProjectByProjectId(id);
            var allEmployees = _employeeService.GetAllEmployees();
            var allEmployeesFullName = allEmployees.Select(x => new
            {
                EmployeeId = x.EmployeeId,
                FullName = $"{x.FirstName} {x.LastName}"
            }).ToList();
            ViewBag.Employees = new SelectList(allEmployeesFullName, "EmployeeId", "FullName");

            projectVM.Employees = _projectService.GetEmployeeByProjectId(id);
            return View(projectVM);
        }
        [HttpPost]
        public IActionResult AddEmployeeToProject(EmployeeProject employeeProject)
        {
            _projectService.AddEmployeeToProject(employeeProject);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(Project project)
        {
            _projectService.UpdateProject(project);
            return RedirectToAction("Index");
        }
    }
}
