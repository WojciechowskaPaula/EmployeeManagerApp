using EmployeeManager.Interfaces;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;
        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
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
        public IActionResult Edit(Manager manager)
        {
            _managerService.Update(manager);
            return RedirectToAction("Index");
        }

    }
}
