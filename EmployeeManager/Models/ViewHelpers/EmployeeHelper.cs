using EmployeeManager.Interfaces;
using EmployeeManager.Models.ViewModels;
using System.Collections.Generic;

namespace EmployeeManager.Models.ViewHelpers
{
    public  class EmployeeHelper
    {
        private readonly IManagerService _managerService;
        private readonly IEmployeeService _employeeService;
        public EmployeeHelper(IManagerService managerService, IEmployeeService employeeService)
        {
            _managerService = managerService;
            _employeeService = employeeService;
        }

        public EmployeeAddVM AddManagerList (EmployeeAddVM employee)
        {
            employee.Managers = new List<ManagerListInfo>();
            var listOfManagers = _managerService.GetListOfManagers();
            foreach (var item in listOfManagers)
            {
                var employeeManager = _employeeService.GetEmployeeById(item.EmployeeId);
                ManagerListInfo managerListInfo = new ManagerListInfo();
                managerListInfo.ManagerId = item.ManagerId;
                managerListInfo.FullName = $"{employeeManager.FirstName} {employeeManager.LastName}";
                employee.Managers.Add(managerListInfo);
            }
            return employee;
        }
    }
}
