using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project1.Dtos.Project;

namespace Project1.Services.ProjectServices
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        public ProjectService(IMapper mapper)
        {
            _mapper = mapper;
        }

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
        

        public async Task<ServiceResponse<GetProjectDto>> AddNew(AddProjectDto newProject)
        {
            var serviceResponse=new ServiceResponse<GetProjectDto>();
            var addedProject=_mapper.Map<Project>(newProject);

            try
                {
                    addedProject.Id=Projects.Max(c=>c.Id)+1;
                    Projects.Add(addedProject);
                    serviceResponse.Data=_mapper.Map<GetProjectDto>(addedProject);
                    serviceResponse.Message=$"User {addedProject.Name} successfully added.";
                    
                }
            catch(Exception ex)
                {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
                }
            return serviceResponse;
        }

        
        public async Task<ServiceResponse<GetProjectDto>> Update(UpdateProjectDto updatedProject)
        {
            var serviceResponse=new ServiceResponse<GetProjectDto>();

            try
            {
                var checkProject=Projects.FirstOrDefault(c=>c.Id==updatedProject.Id);
                if(checkProject!=null)
                {
                    checkProject.Name=updatedProject.Name;
                    checkProject.AccAmount=updatedProject.AccAmount;
                    checkProject.MainContact=updatedProject.MainContact;
                    checkProject.Staffs=updatedProject.Staffs;
                    serviceResponse.Data=_mapper.Map<GetProjectDto>(checkProject);
                }
                else
                {
                    serviceResponse.Data=null;
                    serviceResponse.Success=false;
                    serviceResponse.Message=$"Id {updatedProject.Id} Not Found";
                }

            }
            catch(Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> Delete(int id)
        {
            var serviceResponse=new ServiceResponse<List<GetProjectDto>>();
            var toDelete=Projects.FirstOrDefault(c=>c.Id==id);

            try
            {
                if(toDelete!=null)
                {
                    Projects.Remove(toDelete);
                    serviceResponse.Data=Projects.Select(c=>_mapper.Map<GetProjectDto>(c)).ToList();
                }
                else
                {
                    serviceResponse.Data=null;
                    serviceResponse.Success=false;
                    serviceResponse.Message=$"Id {id} Not Found";
                }
            }
            catch(Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
            }

            return serviceResponse;
        }
    

        public async Task<ServiceResponse<List<GetProjectDto>>> GetAll()
        {
            var serviceResponse=new ServiceResponse<List<GetProjectDto>>();

            serviceResponse.Data=Projects.Select(p=>_mapper.Map<GetProjectDto>(p)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProjectDto>> GetById(int id)
        {
            var serviceResponse=new ServiceResponse<GetProjectDto>();
            var checkId=Projects.FirstOrDefault(c=>c.Id==id);

            try
            {
                if(checkId!=null)
                {
                    serviceResponse.Data=_mapper.Map<GetProjectDto>(checkId);
                }
                else
                {
                    serviceResponse.Data=null;
                    serviceResponse.Success=false;
                    serviceResponse.Message=$"Id {id} Not Found";
                }
            }
            catch(Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> GetByName(string name)
        {
            var serviceResponse=new ServiceResponse<List<GetProjectDto>>();

            var matchedProjects=new List<Project>();
            foreach(Project project in Projects)
            {
                if(project.Name.ToLower().Contains(name.ToLower()))
                {
                    matchedProjects.Add(project);
                }
            }

            try
            {
                if(matchedProjects.Count>=1)
                {
                    serviceResponse.Data=matchedProjects.Select(mc=>_mapper.Map<GetProjectDto>(mc)).ToList();
                }
                else
                {
                    serviceResponse.Data=null;
                    serviceResponse.Success=false;
                    serviceResponse.Message=$"Name containing {name} Not Found";
                }
                
            }
            catch(Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
            }
            return serviceResponse;
        }

    }
}