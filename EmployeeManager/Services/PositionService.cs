using EmployeeManager.Data;
using EmployeeManager.Interfaces;
using EmployeeManager.Models;
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


    }
}
