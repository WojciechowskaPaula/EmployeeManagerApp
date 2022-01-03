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

        public Manager DisplayDetails(int id)
        {
            var managerDetails = _dbContext.Managers.FirstOrDefault(x => x.EmployeeId == id);
            Manager manager = new Manager();
            manager.ManagerId = managerDetails.ManagerId;
            manager.RoomNumber = managerDetails.RoomNumber;
            manager.EmployeeId = managerDetails.EmployeeId;
            return manager;
        }


       
    }
}
