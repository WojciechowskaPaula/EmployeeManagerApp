using EmployeeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Interfaces
{
     public interface IPositionService
    {
        List<Position> GetListOfPositions();
    }
}
