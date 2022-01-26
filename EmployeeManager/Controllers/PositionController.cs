using EmployeeManager.Interfaces;
using EmployeeManager.Models;
using EmployeeManager.Models.ViewModels;
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
            PositionAddVM position = new PositionAddVM();
            return View(position);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewPosition(PositionAddVM position)
        {
            if (!ModelState.IsValid)
            {
                return View("AddNewPositionForm", position);
            }
            var positionToAdd = new Position();
            positionToAdd.PositionId = position.PositionId;
            positionToAdd.PositionName = position.PositionName;
            _positionService.AddNewPosition(positionToAdd);
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
        [HttpGet]
        public IActionResult EditPosition(int positionId)
        {
            var details = _positionService.DisplayPositionDetails(positionId);
            return View(details);
        }
        [HttpPost]
        public IActionResult Update(Position position)
        {
           _positionService.UpdatePosition(position);
            return RedirectToAction("Index");
        }
    }
}
