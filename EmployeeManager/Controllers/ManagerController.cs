using EmployeeManager.Interfaces;
using EmployeeManager.Models;
using EmployeeManager.Models.ViewModels;
using EmployeeManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;
        private readonly IEmployeeService _employeeService;
        public ManagerController(IManagerService managerService, IEmployeeService employeeService)
        {
            _managerService = managerService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listOfManagers = _managerService.GetListOfManagers();
            return View(listOfManagers);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var managerDetails = _managerService.DisplayDetails(id);
           
            return View(managerDetails);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var manager = _managerService.GetMangerByIdForEdit(id);
            return View(manager);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ManagerEditVM manager)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", manager);
            }
            var managerToEdit = new Manager();
            managerToEdit.ManagerId = manager.ManagerId;
            managerToEdit.RoomNumber = manager.RoomNumber;
            managerToEdit.EmployeeId = manager.EmployeeId;
            
            _managerService.Update(managerToEdit);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddNewManagerForm()
        {
            var vm = new ManagerEditVM();
            var allEmployees = _employeeService.GetAllEmployees();
            vm.Employees = allEmployees.Select(x => new SelectListItem()
            {
                Value = x.EmployeeId.ToString(),
                Text = x.EmployeeId.ToString()

            }).ToList();
            
            return View(vm);
        }
        
        [HttpPost]
        public IActionResult AddNewManager(ManagerEditVM managerVM)
        {
            _managerService.AddNewManager(managerVM);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteandConfirm(int id)
        {
            var managerToRemove =_managerService.DisplayDetails(id);
            return View(managerToRemove);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _managerService.DeleteManager(id);
            return RedirectToAction("Index");
        }

    }
}
