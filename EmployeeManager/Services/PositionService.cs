using EmployeeManager.Data;
using EmployeeManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Services
{
    public class PositionService :IPositionService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public PositionService(ApplicationDbContext dbContext)
        {
            _applicationDbContext = dbContext;
        }
    }
}
