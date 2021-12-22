using EmployeeManager.Models;
using EmployeeManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Interfaces
{
     public interface IPositionService
    {
        List<Position> GetListOfPositions();
        PositionAddVM AddNewPosition(Position position);

    }
}
