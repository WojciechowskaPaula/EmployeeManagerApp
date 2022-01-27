using EmployeeManager.Models;
using EmployeeManager.Models.ViewModels;
using System.Collections.Generic;

namespace EmployeeManager.Interfaces
{
    public interface IPositionService
    {
        List<Position> GetListOfPositions();
        PositionAddVM AddNewPosition(Position position);
        PositionDetailsVM DisplayPositionDetails(int positionId);
        void DeletePosition(int positionId);
        void UpdatePosition(PositionDetailsVM position);
        Position GetPositionByEmployee(int employeeId);
    }
}