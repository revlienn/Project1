using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Services.OrganisationServices
{
    public interface IOrganisationService
    {
        Task<ServiceResponse<List<Organisation>>> GetAll();
        Task<ServiceResponse<Organisation>> GetById(int id);
        Task<ServiceResponse<List<Organisation>>> GetByName(string name);
        Task<ServiceResponse<Organisation>> AddNew(Organisation newOrganisation);
        Task<ServiceResponse<Organisation>> Update(Organisation updatedOrganisation);
        Task<ServiceResponse<List<Organisation>>> Delete(int id);
    }
}