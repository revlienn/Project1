using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Services.ProjectServices
{
    public class ProjectService : IProjectService
    {

        private List<Project> Projects=new List<Project>
        {
            new Project()
            {
                Id=1,
                Name="Ellipsis",
                AccAmount=2000000
            },
            new Project()
            {
                Id=2,
                Name="Scorpion",
                AccAmount=9000000
            },
        };
        
        public async Task<Project> AddNew(Project newProject)
        {
            var checkProject=Projects.FirstOrDefault(c=>c.Id==newProject.Id);
            if(checkProject!=null)
            {
                return null;
            }
            Projects.Add(newProject);
            return newProject;
        }

        public async Task<List<Project>> GetAll()
        {
            return Projects;
        }

        public async Task<Project> GetById(int id)
        {
            var checkId=Projects.FirstOrDefault(c=>c.Id==id);
            if(checkId==null)
            {
                return null;
            }
            return checkId;
        }

        public async Task<List<Project>> GetByName(string name)
        {
            var matchedProjects=new List<Project>();
            foreach(Project project in Projects)
            {
                if(project.Name.ToLower().Contains(name))
                {
                    matchedProjects.Add(project);
                }
            }
            if(matchedProjects.Count==0)
            {
                return null;
            }
            return matchedProjects;
        }

        public async Task<Project> Update(Project updatedProject)
        {
            var checkProject=Projects.FirstOrDefault(c=>c.Id==updatedProject.Id);
            if(checkProject==null)
            {
                return null;
            }
            checkProject.Name=updatedProject.Name;
            checkProject.AccAmount=updatedProject.AccAmount;
            checkProject.MainContact=updatedProject.MainContact;
            checkProject.Staffs=updatedProject.Staffs;

            return checkProject;
        }

        public async Task<List<Project>> Delete(int id)
        {
            var toDelete=Projects.FirstOrDefault(c=>c.Id==id);
            if(toDelete==null)
            {
                return null;
            }
            Projects.Remove(toDelete);
            return Projects;
        }
    }
    
}