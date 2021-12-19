using EmployeeManager.Data;
using EmployeeManager.Interfaces;
using EmployeeManager.Models;
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

        public List<Manager> GetListOfManagers()
        {
            var listOfManagers = _dbContext.Managers.ToList();
            
            return listOfManagers;
        }
    }
}
