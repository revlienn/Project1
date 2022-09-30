using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Dtos.Organisation;

namespace Project1.Services.OrganisationServices
{
    public interface IOrganisationService
    {
        Task<ServiceResponse<List<GetOrganisationDto>>> GetAll();
        Task<ServiceResponse<GetOrganisationDto>> GetById(int id);
        Task<ServiceResponse<List<GetOrganisationDto>>> GetByName(string name);
        Task<ServiceResponse<GetOrganisationDto>> AddNew(AddOrganisationDto newOrganisation);
        Task<ServiceResponse<GetOrganisationDto>> Update(UpdateOrganisationDto updatedOrganisation);
        Task<ServiceResponse<List<GetOrganisationDto>>> Delete(int id);
    }
}