using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Services.ProjectServices
{
    public interface IProjectService
    {
        Task<List<Project>> GetAll();
        Task<Project> GetById(int id);
        Task<List<Project>> GetByName(string name);
        Task<Project> AddNew(Project newProject);
        Task<Project> Update(Project updatedProject);
        Task<List<Project>> Delete(int id);
    }
}