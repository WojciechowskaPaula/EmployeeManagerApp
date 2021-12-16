using EmployeeManager.Models;
using EmployeeManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Interfaces
{
    public interface IProjectService
    {
        List<Project> GetProjectByEmployeeId(int id);
        List<Project> GetListOfProjects();
        void DeleteProject(int id);
        Project AddNewProject(Project project);
        ProjectDetailVM DisplayProjectDetails(int id);
        List<Employee> GetEmployeeByProjectId(int projectId);
        Project UpdateProject(Project project);
        ProjectEditVM GetProjectByProjectId(int id);
    }
}
