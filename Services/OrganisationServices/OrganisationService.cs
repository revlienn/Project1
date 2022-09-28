using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Services.OrganisationServices
{
    public class OrganisationService:IOrganisationService
    {
        private List<Organisation> Organisations=new List<Organisation>
        {
            new Organisation()
            {
                Id=1,
                Name="Thames Corporation",
                Phone="020-90909090"
            },
            new Organisation()
            {
                Id=2,
                Name="Big Ben",
                Phone="020-90909090"
            },
            new Organisation()
            {
                Id=3,
                Name="OakTree",
                Phone="020-94638000"
            },
        };

        public async Task<ServiceResponse<Organisation>> AddNew(Organisation newOrganisation)
        {
            var serviceResponse=new ServiceResponse<Organisation>();

            var checkOrganisation=Organisations.FirstOrDefault(c=>c.Id==newOrganisation.Id);
            if(checkOrganisation!=null)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Id {newOrganisation.Id} has been assigned to a different Organisation";
                return serviceResponse;
            }
            Organisations.Add(newOrganisation);

            serviceResponse.Data=newOrganisation;
            serviceResponse.Message=$"Organisation {newOrganisation.Id} successfully added.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Organisation>>> GetAll()
        {
            var serviceResponse=new ServiceResponse<List<Organisation>>();

            serviceResponse.Data=Organisations;

            return serviceResponse;
        }

        public async Task<ServiceResponse<Organisation>> GetById(int id)
        {
            var serviceResponse=new ServiceResponse<Organisation>();

            var checkId=Organisations.FirstOrDefault(c=>c.Id==id);
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

        public async Task<ServiceResponse<List<Organisation>>> GetByName(string name)
        {
            var serviceResponse=new ServiceResponse<List<Organisation>>();

            var matchedOrganisations=new List<Organisation>();
            foreach(Organisation Organisation in Organisations)
            {
                if(Organisation.Name.ToLower().Contains(name))
                {
                    matchedOrganisations.Add(Organisation);
                }
            }
            if(matchedOrganisations.Count==0)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Name containing {name} Not Found";
                return serviceResponse;
            }
            
            serviceResponse.Data=matchedOrganisations;
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<Organisation>> Update(Organisation updatedOrganisation)
        {
            var serviceResponse=new ServiceResponse<Organisation>();

            var checkOrganisation=Organisations.FirstOrDefault(c=>c.Id==updatedOrganisation.Id);
            if(checkOrganisation==null)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Id {updatedOrganisation.Id} Not Found";
                return serviceResponse;
            }
            checkOrganisation.Name=updatedOrganisation.Name;
            checkOrganisation.Phone=updatedOrganisation.Phone;
            checkOrganisation.Contacts=updatedOrganisation.Contacts;
            checkOrganisation.Projects=updatedOrganisation.Projects;

            serviceResponse.Data=checkOrganisation;
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Organisation>>> Delete(int id)
        {
            var serviceResponse=new ServiceResponse<List<Organisation>>();

            var toDelete=Organisations.FirstOrDefault(c=>c.Id==id);

            if(toDelete==null)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Id {id} Not Found";
                return serviceResponse;
            }
            Organisations.Remove(toDelete);

            serviceResponse.Data=Organisations;

            return serviceResponse;
        }
    }
}