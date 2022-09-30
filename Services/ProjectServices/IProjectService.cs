using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Dtos.Project;

namespace Project1.Services.ProjectServices
{
    public interface IProjectService
    {
        Task<ServiceResponse<List<GetProjectDto>>> GetAll();
        Task<ServiceResponse<GetProjectDto>> GetById(int id);
        Task<ServiceResponse<List<GetProjectDto>>> GetByName(string name);
        Task<ServiceResponse<GetProjectDto>> AddNew(AddProjectDto newProject);
        Task<ServiceResponse<GetProjectDto>> Update(UpdateProjectDto updatedProject);
        Task<ServiceResponse<List<GetProjectDto>>> Delete(int id);
    }
}