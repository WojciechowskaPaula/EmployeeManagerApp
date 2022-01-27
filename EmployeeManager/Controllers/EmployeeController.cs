using EmployeeManager.Interfaces;
using EmployeeManager.Models;
using EmployeeManager.Models.ViewHelpers;
using EmployeeManager.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IProjectService _projectService;
        private readonly IManagerService _managerService;
        private readonly IPositionService _positionService;
        private readonly EmployeeHelper _employeeHelper;

        public EmployeeController(IEmployeeService employeeService, IProjectService projectService, IManagerService managerService,
            IPositionService positionService, EmployeeHelper employeeHelper)
        {
            _employeeService = employeeService;
            _projectService = projectService;
            _managerService = managerService;
            _positionService = positionService;
            _employeeHelper = employeeHelper;
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
            var employeePosition = _positionService.GetPositionByEmployee(id);
            var details = _employeeService.GetEmployeeDetail(id);
            details.Projects = employeeProject;
            details.Position = employeePosition;

            return View(details);
        }

        [HttpGet]
        public IActionResult AddEmployeeForm()
        {
            EmployeeAddVM employeeAddVM = new EmployeeAddVM();
            employeeAddVM = _employeeHelper.AddManagerList(employeeAddVM);
            return View(employeeAddVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewEmployee(EmployeeAddVM employee)
        {
            if (!ModelState.IsValid)
            {
                employee = _employeeHelper.AddManagerList(employee);
                return View("AddEmployeeForm", employee);
            }
            var employeeToAdd = new Employee(employee);
            _employeeService.AddNewEmployee(employeeToAdd);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditEmployeeForm(int id)
        {
            var edit = _employeeService.GetEmployeeByIdForEdit(id);
            edit = FillEmployeeEditVM(edit);
            return View(edit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(EmployeeEditVM employee)
        {
            if (!ModelState.IsValid)
            {
                employee = FillEmployeeEditVM(employee);
                return View("EditEmployeeForm", employee);
            }
            var employeeToUpdate = new Employee(employee);
            _employeeService.UpdateEmployee(employeeToUpdate);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProjectToEmployee(EmployeeProject employeeProject)
        {
            _projectService.AddEmployeeToProject(employeeProject);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteProjectFromEmployee(int projectID, int employeeId)
        {
            _projectService.DeleteProjectFromEmployee(projectID, employeeId);
            return RedirectToAction("EditemployeeForm", new { id = employeeId });
        }

        private EmployeeEditVM FillEmployeeEditVM(EmployeeEditVM editVM)
        {
            editVM.Positions = _positionService.GetListOfPositions();
            var namesOfPositions = editVM.Positions.Select(x => new
            {
                PositionId = x.PositionId,
                PositionName = x.PositionName
            });
            var employeePosition = _positionService.GetPositionByEmployee(editVM.EmployeeId);
            var positionSelectList = new SelectList(namesOfPositions, "PositionId", "PositionName");
            positionSelectList.Where(x => x.Value == employeePosition.PositionId.ToString()).FirstOrDefault().Selected = true;
            ViewBag.Positions = positionSelectList;

            editVM.Managers = new List<ManagerListInfo>();
            var listOfManagers = _managerService.GetListOfManagers();
            foreach (var item in listOfManagers)
            {
                var employee = _employeeService.GetEmployeeById(item.EmployeeId);
                ManagerListInfo managerListInfo = new ManagerListInfo
                {
                    ManagerId = item.ManagerId,
                    FullName = $"{employee.FirstName} {employee.LastName}"
                };
                editVM.Managers.Add(managerListInfo);
            }

            editVM.Projects = _projectService.GetProjectByEmployeeId(editVM.EmployeeId);
            var listOfProjects = _projectService.GetListOfProjects();
            listOfProjects = listOfProjects.Except(editVM.Projects).ToList();
            var namesOfProjects = listOfProjects.Select(x => new
            {
                ProjectId = x.ProjectId,
                ProjectName = x.ProjectName
            });
            ViewBag.Projects = new SelectList(namesOfProjects, "ProjectId", "ProjectName");

            return editVM;
        }
    }
}
