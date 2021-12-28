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

        [HttpGet]
        public IActionResult AddNewPosition(Position position)
        {
           var newPosition = _positionService.AddNewPosition(position);
            return RedirectToAction("Index");
        }

        [HttpGet]
       public IActionResult DisplayPositionDetails(int positionId)
        {
            var details = _positionService.DisplayPositionDetails(positionId);
            return View(details);
        }

        [HttpGet]
        public IActionResult DeleteAndConfirm(int positionId)
        {
            var positionToDelete = _positionService.DisplayPositionDetails(positionId);
            return View(positionToDelete);
        }

        [HttpPost]
        public IActionResult Delete (int positionId)
        {
            _positionService.DeletePosition(positionId);
            return RedirectToAction("Index");
        }

    }
}
