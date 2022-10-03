using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project1.Dtos.Organisation;

namespace Project1.Services.OrganisationServices
{
    public class OrganisationService:IOrganisationService
    {
        private readonly IMapper _mapper;
        public OrganisationService(IMapper mapper)
        {
            _mapper = mapper;
        }
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
        

        public async Task<ServiceResponse<GetOrganisationDto>> AddNew(AddOrganisationDto newOrganisation)
        {
            var serviceResponse=new ServiceResponse<GetOrganisationDto>();
            var addedOrganisation=_mapper.Map<Organisation>(newOrganisation);

            try
                {
                    addedOrganisation.Id=Organisations.Max(c=>c.Id)+1;
                    Organisations.Add(addedOrganisation);
                    serviceResponse.Data=_mapper.Map<GetOrganisationDto>(addedOrganisation);
                    serviceResponse.Message=$"User {addedOrganisation.Name} successfully added.";
                    
                }
            catch(Exception ex)
                {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
                }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetOrganisationDto>> Update(UpdateOrganisationDto updatedOrganisation)
        {
            var serviceResponse=new ServiceResponse<GetOrganisationDto>();

            try
            {
                Organisation checkOrganisation=Organisations.FirstOrDefault(c=>c.Id==updatedOrganisation.Id);
                if(checkOrganisation!=null)
                {
                    //_mapper.Map(updatedOrganisation,checkOrganisation);
                    checkOrganisation.Name=updatedOrganisation.Name;
                    checkOrganisation.Phone=updatedOrganisation.Phone;
                    checkOrganisation.Contacts=updatedOrganisation.Contacts;
                    checkOrganisation.Projects=updatedOrganisation.Projects;
                    serviceResponse.Data=_mapper.Map<GetOrganisationDto>(checkOrganisation);
                }
                else
                {
                    serviceResponse.Data=null;
                    serviceResponse.Success=false;
                    serviceResponse.Message=$"Id {updatedOrganisation.Id} Not Found";
                }

            }
            catch(Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetOrganisationDto>>> Delete(int id)
        {
            var serviceResponse=new ServiceResponse<List<GetOrganisationDto>>();
            var toDelete=Organisations.FirstOrDefault(c=>c.Id==id);

            try
            {
                if(toDelete!=null)
                {
                    Organisations.Remove(toDelete);
                    serviceResponse.Data=Organisations.Select(c=>_mapper.Map<GetOrganisationDto>(c)).ToList();
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

        public async Task<ServiceResponse<List<GetOrganisationDto>>> GetAll()
        {
            var serviceResponse=new ServiceResponse<List<GetOrganisationDto>>();

            serviceResponse.Data=Organisations.Select(o=>_mapper.Map<GetOrganisationDto>(o)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetOrganisationDto>> GetById(int id)
        {
            var serviceResponse=new ServiceResponse<GetOrganisationDto>();
            var checkId=Organisations.FirstOrDefault(c=>c.Id==id);

            try
            {
                if(checkId!=null)
                {
                    serviceResponse.Data=_mapper.Map<GetOrganisationDto>(checkId);
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

        public async Task<ServiceResponse<List<GetOrganisationDto>>> GetByName(string name)
        {
            var serviceResponse=new ServiceResponse<List<GetOrganisationDto>>();

            var matchedOrganisations=new List<Organisation>();
            foreach(Organisation organisation in Organisations)
            {
                if(organisation.Name.ToLower().Contains(name.ToLower()))
                {
                    matchedOrganisations.Add(organisation);
                }
            }

            try
            {
                if(matchedOrganisations.Count>=1)
                {
                    serviceResponse.Data=matchedOrganisations.Select(mc=>_mapper.Map<GetOrganisationDto>(mc)).ToList();
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