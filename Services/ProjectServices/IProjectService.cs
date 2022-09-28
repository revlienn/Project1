using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Services.ProjectServices
{
    public interface IProjectService
    {
        Task<ServiceResponse<List<Project>>> GetAll();
        Task<ServiceResponse<Project>> GetById(int id);
        Task<ServiceResponse<List<Project>>> GetByName(string name);
        Task<ServiceResponse<Project>> AddNew(Project newProject);
        Task<ServiceResponse<Project>> Update(Project updatedProject);
        Task<ServiceResponse<List<Project>>> Delete(int id);
    }
}