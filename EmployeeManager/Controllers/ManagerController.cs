using EmployeeManager.Interfaces;
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
        public IActionResult Index()
        {
            var listOfManagers = _managerService.GetListOfManagers();
            return View(listOfManagers);
        }
    }
}
