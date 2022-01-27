using EmployeeManager.Models;
using EmployeeManager.Models.ViewModels;
using System.Collections.Generic;

namespace EmployeeManager.Interfaces
{
    public interface IProjectService
    {
        List<Project> GetProjectByEmployeeId(int id);
        List<Project> GetListOfProjects();
        void DeleteProject(int id);
        void DeleteProjectFromEmployee(int projectId, int employeeId);
        Project AddNewProject(Project project);
        ProjectDetailVM DisplayProjectDetails(int id);
        List<Employee> GetEmployeeByProjectId(int projectId);
        Project UpdateProject(Project project);
        ProjectEditVM GetProjectByProjectId(int id);
        void AddEmployeeToProject(EmployeeProject employeeProject);
    }
}
