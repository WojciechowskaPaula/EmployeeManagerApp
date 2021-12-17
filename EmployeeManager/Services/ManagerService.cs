using EmployeeManager.Data;
using EmployeeManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Services
{
    public class ManagerService : IManagerService
    {
        private readonly ApplicationDbContext _dbContext;
        public ManagerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
    }
}
