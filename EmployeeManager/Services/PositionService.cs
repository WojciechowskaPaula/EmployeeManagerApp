﻿using EmployeeManager.Data;
using EmployeeManager.Interfaces;
using EmployeeManager.Models;
using EmployeeManager.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManager.Services
{
    public class PositionService : IPositionService
    {
        private readonly ApplicationDbContext _dbContext;
        public PositionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Position> GetListOfPositions()
        {
            var allPositions = _dbContext.Positions.ToList();
            return allPositions;
        }

        public PositionAddVM AddNewPosition(Position position)
        {
            PositionAddVM newPosition = new PositionAddVM
            {
                PositionId = position.PositionId,
                PositionName = position.PositionName
            };
            _dbContext.Positions.Add(position);
            _dbContext.SaveChanges();
            return newPosition;
        }

        public PositionDetailsVM DisplayPositionDetails(int positionId)
        {
            var position = _dbContext.Positions.FirstOrDefault(x => x.PositionId == positionId);
            PositionDetailsVM positionDetails = new PositionDetailsVM
            {
                PositionId = position.PositionId,
                PositionName = position.PositionName
            };
            return positionDetails;
        }

        public void DeletePosition(int positionId)
        {
            var positionToRemove = _dbContext.Positions.FirstOrDefault(x => x.PositionId == positionId);
            _dbContext.Positions.Remove(positionToRemove);
            _dbContext.SaveChanges();
        }

        public void UpdatePosition(PositionDetailsVM position)
        {
            var positionToEdit = _dbContext.Positions.FirstOrDefault(x => x.PositionId == position.PositionId);
            positionToEdit.PositionId = position.PositionId;
            positionToEdit.PositionName = position.PositionName;
            _dbContext.SaveChanges();
        }

        public Position GetPositionByEmployee(int employeeId)
        {
            var positionId = _dbContext.JobHistoryPosition.Where(x => x.JobHistory.EmployeeId == employeeId).FirstOrDefault().PositionId;
            var position = _dbContext.Positions.FirstOrDefault(x => x.PositionId == positionId);
            return position;
        }
    }
}