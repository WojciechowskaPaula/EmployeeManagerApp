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
        Manager DisplayDetails(int id);
        ManagerEditVM GetMangerByIdForEdit(int id);
        Manager Update(Manager manager);
    }
}
