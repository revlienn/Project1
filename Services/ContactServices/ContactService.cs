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

        public async Task<Contact> AddNew(Contact newContact)
        {
            var checkContact=Contacts.FirstOrDefault(c=>c.Id==newContact.Id);
            if(checkContact!=null)
            {
                return null;
            }
            Contacts.Add(newContact);
            return newContact;
        }

        public async Task<List<Contact>> GetAll()
        {
            return Contacts;
        }

        public async Task<Contact> GetById(int id)
        {
            var checkId=Contacts.FirstOrDefault(c=>c.Id==id);
            if(checkId==null)
            {
                return null;
            }
            return checkId;
        }

        public async Task<List<Contact>> GetByName(string name)
        {
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
                return null;
            }
            return matchedContacts;
        }

        public async Task<Contact> Update(Contact updatedContact)
        {
            var checkContact=Contacts.FirstOrDefault(c=>c.Id==updatedContact.Id);
            if(checkContact==null)
            {
                return null;
            }
            checkContact.Name=updatedContact.Name;
            checkContact.Email=updatedContact.Email;
            checkContact.OrganisationId=updatedContact.OrganisationId;

            return checkContact;
        }

        public async Task<List<Contact>> Delete(int id)
        {
            var toDelete=Contacts.FirstOrDefault(c=>c.Id==id);
            if(toDelete==null)
            {
                return null;
            }
            Contacts.Remove(toDelete);
            return Contacts;
        }
    }
}