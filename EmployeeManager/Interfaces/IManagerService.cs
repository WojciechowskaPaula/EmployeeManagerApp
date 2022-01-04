using EmployeeManager.Models;
using EmployeeManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Interfaces
{
    public interface IManagerService
    {
        List<Manager> GetListOfManagers();
        ManagerDetailVM DisplayDetails(int id);
        ManagerEditVM GetMangerByIdForEdit(int id);
        Manager Update(Manager manager);
        Manager AddNewManager(ManagerEditVM managerEditVM);
        Manager GetManagerById(int id);
        void DeleteManager(int id);
    }
}
