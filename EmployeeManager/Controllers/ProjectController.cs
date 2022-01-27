using EmployeeManager.Interfaces;
using EmployeeManager.Models;
using EmployeeManager.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

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
        [ValidateAntiForgeryToken]
        public IActionResult AddNewProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View("AddNewProject", project);
            }
            _projectService.AddNewProject(project);
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
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _projectService.DeleteProject(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteFromEmployee(int projectId, int employeeId)
        {
            _projectService.DeleteProjectFromEmployee(projectId, employeeId);
            return RedirectToAction("EditProjectForm", new { id = projectId });
        }

        [HttpGet]
        public IActionResult EditProjectForm(int id)
        {
            var projectVM = _projectService.GetProjectByProjectId(id);
            projectVM = FillProjectEditVM(projectVM);
            return View(projectVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmployeeToProject(EmployeeProject employeeProject)
        {
            _projectService.AddEmployeeToProject(employeeProject);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ProjectEditVM project)
        {
            if (!ModelState.IsValid)
            {
                FillProjectEditVM(project);
                return View("EditProjectForm", project);
            }
            _projectService.UpdateProject(project);

            return RedirectToAction("Index");
        }
        private ProjectEditVM FillProjectEditVM(ProjectEditVM editVM)
        {
            var allEmployees = _employeeService.GetAllEmployees();
            editVM.Employees = _projectService.GetEmployeeByProjectId(editVM.ProjectId);
            allEmployees = allEmployees.Except(editVM.Employees).ToList();
            var allEmployeesFullName = allEmployees.Select(x => new
            {
                EmployeeId = x.EmployeeId,
                FullName = $"{x.FirstName} {x.LastName}"
            }).ToList();
            ViewBag.Employees = new SelectList(allEmployeesFullName, "EmployeeId", "FullName");

            return editVM;
        }
    }
}
