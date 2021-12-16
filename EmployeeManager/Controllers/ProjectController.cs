﻿using EmployeeManager.Interfaces;
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

        public IActionResult Index()
        {
            var projects = _projectService.GetListOfProjects();
            return View(projects);
        }

        public IActionResult AddNewProject(Project project)
        {
           var newProject = _projectService.AddNewProject(project);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
           var employeeList = _projectService.GetEmployeeByProjectId(id);
           var details = _projectService.DisplayProjectDetails(id);
            details.Employees = employeeList;
            return View(details);
        }

        public IActionResult Delete(int id)
        {
            _projectService.DeleteProject(id);
            return RedirectToAction("Index");
        }
    }
}