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

        public ManagerDetailVM DisplayDetails(int id)
        {
            var managerDetails = _dbContext.Managers.FirstOrDefault(x => x.ManagerId == id);
            var managerVM = new ManagerDetailVM();
            managerVM.ManagerId = managerDetails.ManagerId;
            managerVM.RoomNumber = managerDetails.RoomNumber;
            managerVM.EmployeeId = managerDetails.EmployeeId;
            managerVM.Employees = _dbContext.Employees.Where(x => x.ManagerId == id).ToList();
            return managerVM;
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
        
        public Manager AddNewManager(ManagerEditVM managerVM)
        {
            Manager newManager = new Manager();
            newManager.ManagerId = managerVM.ManagerId;
            newManager.RoomNumber = managerVM.RoomNumber;
            newManager.EmployeeId = managerVM.EmployeeId;
           _dbContext.Managers.Add(newManager);
            _dbContext.SaveChanges();
            return newManager;
        }

        public Manager GetManagerById(int id)
        {
            var manager = _dbContext.Managers.FirstOrDefault(x => x.ManagerId == id);
            return manager;
        }
        public void DeleteManager (int id)
        {
            var managerToRemove = _dbContext.Managers.FirstOrDefault(x => x.ManagerId == id);
            _dbContext.Managers.Remove(managerToRemove);
            _dbContext.SaveChanges();
        }

    }
}
