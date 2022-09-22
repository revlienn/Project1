using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Services.OrganisationServices
{
    public interface IOrganisationService
    {
        Task<Organisation> AddNew(Organisation newOrganisation);
        Task<Organisation> Update(Organisation updatedOrganisation);
        Task<List<Organisation>> Delete(int id);
        Task<List<Organisation>> GetAll();
        Task<Organisation> GetById(int id);
        Task<List<Organisation>> GetByName(string name);
    }
}