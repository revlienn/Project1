using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Services.ContactServices
{
    public class ContactService:IContactService
    {
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

        public async Task<ServiceResponse<Contact>> AddNew(Contact newContact)
        {
            var serviceResponse=new ServiceResponse<Contact>();

            var checkContact=Contacts.FirstOrDefault(c=>c.Id==newContact.Id);
            if(checkContact!=null)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Id {newContact.Id} has been assigned to a different user";
                return serviceResponse;
            }
            Contacts.Add(newContact);

            serviceResponse.Data=newContact;
            serviceResponse.Message=$"User {newContact.Name} successfully added.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Contact>>> GetAll()
        {
            var serviceResponse=new ServiceResponse<List<Contact>>();

            serviceResponse.Data=Contacts;

            return serviceResponse;
        }

        public async Task<ServiceResponse<Contact>> GetById(int id)
        {
            var serviceResponse=new ServiceResponse<Contact>();

            var checkId=Contacts.FirstOrDefault(c=>c.Id==id);
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

        public async Task<ServiceResponse<List<Contact>>> GetByName(string name)
        {
            var serviceResponse=new ServiceResponse<List<Contact>>();

            var matchedContacts=new List<Contact>();
            foreach(Contact contact in Contacts)
            {
                if(contact.Name.ToLower().Contains(name))
                {
                    matchedContacts.Add(contact);
                }
            }
            if(matchedContacts.Count==0)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Name containing {name} Not Found";
                return serviceResponse;
            }
            
            serviceResponse.Data=matchedContacts;
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<Contact>> Update(Contact updatedContact)
        {
            var serviceResponse=new ServiceResponse<Contact>();

            var checkContact=Contacts.FirstOrDefault(c=>c.Id==updatedContact.Id);
            if(checkContact==null)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Id {updatedContact.Id} Not Found";
                return serviceResponse;
            }
            checkContact.Name=updatedContact.Name;
            checkContact.Email=updatedContact.Email;
            checkContact.OrganisationId=updatedContact.OrganisationId;

            serviceResponse.Data=checkContact;
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Contact>>> Delete(int id)
        {
            var serviceResponse=new ServiceResponse<List<Contact>>();

            var toDelete=Contacts.FirstOrDefault(c=>c.Id==id);

            if(toDelete==null)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Id {id} Not Found";
                return serviceResponse;
            }
            Contacts.Remove(toDelete);

            serviceResponse.Data=Contacts;

            return serviceResponse;
        }
    }
}