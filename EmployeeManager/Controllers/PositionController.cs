using EmployeeManager.Interfaces;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        [HttpGet]
        public IActionResult Index()
        {
           var positions = _positionService.GetListOfPositions();
            return View(positions);
        }

        [HttpGet]
        public IActionResult AddNewPositionForm()
        {
            return View();
        }

        public IActionResult AddNewPosition(Position position)
        {
           var newPosition = _positionService.AddNewPosition(position);
            return RedirectToAction("Index");
        }
    }
}
