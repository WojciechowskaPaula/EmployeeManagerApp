using EmployeeManager.Interfaces;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
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
        public IActionResult EditProjectForm(int id)
        {
            var project = _projectService.GetProjectByProjectId(id);
            project.Employees = _projectService.GetEmployeeByProjectId(id);

            return View(project);
        }

        [HttpPost]
        public IActionResult Update(Project project)
        {
            _projectService.UpdateProject(project);
            return RedirectToAction("Index");
        }
    }
}
