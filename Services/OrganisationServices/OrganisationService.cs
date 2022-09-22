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

        public async Task<Organisation> AddNew(Organisation newOrganisation)
        {
            var checkOrganisation=Organisations.FirstOrDefault(c=>c.Id==newOrganisation.Id);
            if(checkOrganisation!=null)
            {
                return null;
            }
            Organisations.Add(newOrganisation);
            return newOrganisation;
        }

        public async Task<List<Organisation>> GetAll()
        {
            return Organisations;
        }

        public async Task<Organisation> GetById(int id)
        {
            var checkId=Organisations.FirstOrDefault(c=>c.Id==id);
            if(checkId==null)
            {
                return null;
            }
            return checkId;
        }

        public async Task<List<Organisation>> GetByName(string name)
        {
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
                return null;
            }
            return matchedOrganisations;
        }

        public async Task<Organisation> Update(Organisation updatedOrganisation)
        {
            var checkOrganisation=Organisations.FirstOrDefault(c=>c.Id==updatedOrganisation.Id);
            if(checkOrganisation==null)
            {
                return null;
            }
            checkOrganisation.Name=updatedOrganisation.Name;
            checkOrganisation.Phone=updatedOrganisation.Phone;
            checkOrganisation.Contacts=updatedOrganisation.Contacts;
            checkOrganisation.Projects=updatedOrganisation.Projects;

            return checkOrganisation;
        }

        public async Task<List<Organisation>> Delete(int id)
        {
            var toDelete=Organisations.FirstOrDefault(c=>c.Id==id);
            if(toDelete==null)
            {
                return null;
            }
            Organisations.Remove(toDelete);
            return Organisations;
        }
    }
}