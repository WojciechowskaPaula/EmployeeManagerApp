using EmployeeManager.Data;
using EmployeeManager.Interfaces;
using EmployeeManager.Models;
using EmployeeManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Services
{
    public class PositionService :IPositionService
    {
        private readonly ApplicationDbContext _dbContext;
        public PositionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Position> GetListOfPositions()
        {
           var allPositions =  _dbContext.Positions.ToList();
            return allPositions;
        }

        public PositionAddVM AddNewPosition(Position position)
        {
            PositionAddVM newPosition = new PositionAddVM();
            newPosition.PositionId = position.PositionId;
            newPosition.PositionName = position.PositionName;
            _dbContext.Positions.Add(position);
            _dbContext.SaveChanges();
            return newPosition;
        }

    }
}
