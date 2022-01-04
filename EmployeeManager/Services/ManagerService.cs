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
            var managerDetails = _dbContext.Managers.FirstOrDefault(x => x.ManagerId == id);
            Manager manager = new Manager();
            manager.ManagerId = managerDetails.ManagerId;
            manager.RoomNumber = managerDetails.RoomNumber;
            manager.EmployeeId = managerDetails.EmployeeId;
            return manager;
        }
        public ManagerEditVM GetMangerByIdForEdit(int id)
        {
            var manager =_dbContext.Managers.FirstOrDefault(x => x.ManagerId == id);
            var vm = new ManagerEditVM();
            vm.ManagerId = manager.ManagerId;
            vm.RoomNumber = manager.RoomNumber;
            vm.EmployeeId = manager.EmployeeId;
            return vm;
        }

        public Manager Update(Manager manager)
        {
            var oldManager = _dbContext.Managers.FirstOrDefault(x => x.ManagerId == manager.ManagerId);
            oldManager.ManagerId = manager.ManagerId;
            oldManager.RoomNumber = manager.RoomNumber;
            oldManager.EmployeeId = manager.EmployeeId;
            _dbContext.SaveChanges();
            return manager;
        }
    }
}
