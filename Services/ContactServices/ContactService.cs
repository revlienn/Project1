using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project1.Dtos.Contact;

namespace Project1.Services.ContactServices
{
    public class ContactService:IContactService
    {

        private readonly IMapper _mapper;
        public ContactService(IMapper mapper)
        {
            _mapper = mapper;
        }
        private List<Contact> Contacts=new List<Contact>
        {
            new Contact()
            {
                Id=1,
                Name="Steve Dell",
                Email="sdell@email.co.uk"
            },
            new Contact()
            {
                Id=2,
                Name="Ben Apple",
                Email="bapple@email.co.uk"
            },
            new Contact()
            {
                Id=3,
                Name="Anne Voss",
                Email="avoss@email.co.uk"
            },
        };

        public async Task<ServiceResponse<GetContactDto>> AddNew(AddContactDto newContact)
        {
            var serviceResponse=new ServiceResponse<GetContactDto>();
            var convContact=_mapper.Map<Contact>(newContact);

            try
                {
                var checkContact=Contacts.FirstOrDefault(c=>c.Id==convContact.Id);
                if(checkContact==null)
                    {
                    Contacts.Add(convContact);
                    serviceResponse.Data=_mapper.Map<GetContactDto>(convContact);
                    serviceResponse.Message=$"User {convContact.Name} successfully added.";
                    }

                else
                    {
                    serviceResponse.Data=null;
                    serviceResponse.Success=false;
                    serviceResponse.Message=$"Id {convContact.Id} has been assigned to a different user";
                    }
                }
            catch(Exception ex)
                {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
                }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetContactDto>>> GetAll()
        {
            var serviceResponse=new ServiceResponse<List<GetContactDto>>();

            serviceResponse.Data=Contacts.Select(c=>_mapper.Map<GetContactDto>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetContactDto>> GetById(int id)
        {
            var serviceResponse=new ServiceResponse<GetContactDto>();
            var checkId=Contacts.FirstOrDefault(c=>c.Id==id);

            try
            {
                if(checkId!=null)
                {
                    serviceResponse.Data=_mapper.Map<GetContactDto>(checkId);
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

        public async Task<ServiceResponse<List<GetContactDto>>> GetByName(string name)
        {
            var serviceResponse=new ServiceResponse<List<GetContactDto>>();

            var matchedContacts=new List<Contact>();
            foreach(Contact contact in Contacts)
            {
                if(contact.Name.ToLower().Contains(name))
                {
                    matchedContacts.Add(contact);
                }
            }

            try
            {
                if(matchedContacts.Count>=1)
                {
                    serviceResponse.Data=matchedContacts.Select(mc=>_mapper.Map<GetContactDto>(mc)).ToList();
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

        public async Task<ServiceResponse<GetContactDto>> Update(UpdateContactDto updatedContact)
        {
            var serviceResponse=new ServiceResponse<GetContactDto>();
            var convContact=_mapper.Map<Contact>(updatedContact);

            try
            {
                var checkContact=Contacts.FirstOrDefault(c=>c.Id==updatedContact.Id);
                if(checkContact!=null)
                {
                    checkContact.Name=updatedContact.Name;
                    checkContact.Email=updatedContact.Email;
                    checkContact.OrganisationId=updatedContact.OrganisationId;
                    serviceResponse.Data=_mapper.Map<GetContactDto>(checkContact);
                }
                else
                {
                    serviceResponse.Data=null;
                    serviceResponse.Success=false;
                    serviceResponse.Message=$"Id {updatedContact.Id} Not Found";
                }

            }
            catch(Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetContactDto>>> Delete(int id)
        {
            var serviceResponse=new ServiceResponse<List<GetContactDto>>();
            var toDelete=Contacts.FirstOrDefault(c=>c.Id==id);

            try
            {
                if(toDelete!=null)
                {
                    Contacts.Remove(toDelete);
                    serviceResponse.Data=Contacts.Select(c=>_mapper.Map<GetContactDto>(c)).ToList();
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
    }
}