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
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProjectService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Project> GetProjectByEmployeeId(int id)
        {
            var projectList = _dbContext.EmployeeProject.Where(x=>x.EmployeeId == id).Select(y=> y.Project).ToList();
            return projectList;
        }

        public List<Project> GetListOfProjects()
        {
            var projects = _dbContext.Projects.ToList();
            return projects;
        }

        public ProjectDetailVM DisplayProjectDetails(int projectId)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.ProjectId == projectId);
            ProjectDetailVM detailVM = new ProjectDetailVM();
            detailVM.ProjectId = project.ProjectId;
            detailVM.ProjectName = project.ProjectName;
            return detailVM;
            
        }

        public List<Employee> GetEmployeeByProjectId(int projectId)
        {
            var employee = _dbContext.EmployeeProject.Where(x => x.ProjectId == projectId).Select(y=>y.Employee).ToList();
            return employee;
        }
       
        
        public void DeleteProject(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.ProjectId == id);
            _dbContext.Remove(project);
            _dbContext.SaveChanges();
        }
      
        public void DeleteProjectFromEmployee(int projectId, int employeeId)
        {
            var project = _dbContext.EmployeeProject.Where(x => x.EmployeeId == employeeId && x.ProjectId == projectId).FirstOrDefault();
            _dbContext.Remove(project);
            _dbContext.SaveChanges();
        }

        public Project AddNewProject(Project project)
        {
            var newProject = new Project();
            newProject.ProjectId = project.ProjectId;
            newProject.ProjectName = project.ProjectName;
            _dbContext.Add(newProject);
            _dbContext.SaveChanges();
            return newProject;
        }

        public ProjectEditVM GetProjectByProjectId(int id)
        {
           var project = _dbContext.Projects.FirstOrDefault(x => x.ProjectId == id);
            var editProject = new ProjectEditVM();
            editProject.ProjectId = project.ProjectId;
            editProject.ProjectName = project.ProjectName;
            return editProject;
        }
       
       public Project UpdateProject(Project project)
        {
            var oldProject = _dbContext.Projects.FirstOrDefault(x => x.ProjectId == project.ProjectId);
            oldProject.ProjectId = project.ProjectId;
            oldProject.ProjectName = project.ProjectName;
            _dbContext.SaveChanges();
            return project;
        }

        public void AddEmployeeToProject(EmployeeProject employeeProject)
        {
            _dbContext.EmployeeProject.Add(employeeProject);
            _dbContext.SaveChanges();
        }


    }
}
