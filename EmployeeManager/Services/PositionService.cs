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

        public PositionDetailsVM DisplayPositionDetails(int positionId)
        {
            var position = _dbContext.Positions.FirstOrDefault(x => x.PositionId == positionId);
            PositionDetailsVM positionDetails = new PositionDetailsVM();
            positionDetails.PositionId = position.PositionId;
            positionDetails.PositionName = position.PositionName;
            return positionDetails;
        }

        public void DeletePosition(int positionId)
        {
            var positionToRemove = _dbContext.Positions.FirstOrDefault(x => x.PositionId == positionId);
            _dbContext.Positions.Remove(positionToRemove);
            _dbContext.SaveChanges();
        }

        public void UpdatePosition(Position position)
        {
            var positionToEdit = _dbContext.Positions.FirstOrDefault(x => x.PositionId == position.PositionId);
            positionToEdit.PositionName = position.PositionName;
            _dbContext.SaveChanges();
        }

        


    }
}
