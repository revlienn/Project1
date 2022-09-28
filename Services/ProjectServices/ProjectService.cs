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
        
        public async Task<ServiceResponse<Project>> AddNew(Project newProject)
        {
            var serviceResponse=new ServiceResponse<Project>();

            var checkProject=Projects.FirstOrDefault(c=>c.Id==newProject.Id);
            if(checkProject!=null)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Id {newProject.Id} has been assigned to a different project";
                return serviceResponse;
            }
            Projects.Add(newProject);

            serviceResponse.Data=newProject;
            serviceResponse.Message=$"Project {newProject.Id} successfully added.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Project>>> GetAll()
        {
            var serviceResponse=new ServiceResponse<List<Project>>();

            serviceResponse.Data=Projects;

            return serviceResponse;
        }

        public async Task<ServiceResponse<Project>> GetById(int id)
        {
            var serviceResponse=new ServiceResponse<Project>();

            var checkId=Projects.FirstOrDefault(c=>c.Id==id);
            if(checkId==null)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Id {id} Not Found";
                return serviceResponse;
            }

            serviceResponse.Data=checkId;

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Project>>> GetByName(string name)
        {
            var serviceResponse=new ServiceResponse<List<Project>>();

            var matchedProjects=new List<Project>();
            foreach(Project Project in Projects)
            {
                if(Project.Name.ToLower().Contains(name))
                {
                    matchedProjects.Add(Project);
                }
            }
            if(matchedProjects.Count==0)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Name containing {name} Not Found";
                return serviceResponse;
            }
            
            serviceResponse.Data=matchedProjects;
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<Project>> Update(Project updatedProject)
        {
            var serviceResponse=new ServiceResponse<Project>();

            var checkProject=Projects.FirstOrDefault(c=>c.Id==updatedProject.Id);
            if(checkProject==null)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Id {updatedProject.Id} Not Found";
                return serviceResponse;
            }
            checkProject.Name=updatedProject.Name;
            checkProject.AccAmount=updatedProject.AccAmount;
            checkProject.MainContact=updatedProject.MainContact;
            checkProject.Staffs=updatedProject.Staffs;

            serviceResponse.Data=checkProject;
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Project>>> Delete(int id)
        {
            var serviceResponse=new ServiceResponse<List<Project>>();

            var toDelete=Projects.FirstOrDefault(c=>c.Id==id);

            if(toDelete==null)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Id {id} Not Found";
                return serviceResponse;
            }
            Projects.Remove(toDelete);

            serviceResponse.Data=Projects;

            return serviceResponse;
        }
    }
    
}