using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project1.Controllers
{
    [ApiController]
    [Route("Contact")]
    public class ContactController:ControllerBase
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

        [HttpGet("ById")]
        public ActionResult<Contact> GetContactById(int Id)
        {
            return Ok(Contacts.FirstOrDefault(c=>c.Id==Id));
        }

        [HttpGet("All")]
        public ActionResult<List<Contact>> GetAllContacts()
        {
            return Ok(Contacts);
        }

        [HttpGet("ByName")]
        public ActionResult<List<Contact>> GetContactByName(string name)
        {
            var matchingContact=new List<Contact>();
            foreach(Contact contact in Contacts)
            {
                if(contact.Name.ToLower().Contains(name))
                {
                    matchingContact.Add(contact);
                }
            }
            return Ok(matchingContact);
        }

        [HttpPost]
        public ActionResult<List<Contact>> AddNewContact(Contact newContact)
        {   
            var contact=Contacts.FirstOrDefault(s=>s.Id==newContact.Id);
            if(contact!=null)
            {
                return StatusCode(409, $"User '{contact.Name}' already exists.");
            }
            Contacts.Add(newContact);
            return Ok(Contacts);
        }

        [HttpPut]
        public ActionResult<Contact> Update(Contact updatedContact)
        {
            var contact=Contacts.FirstOrDefault(s=>s.Id==updatedContact.Id);
            if(contact==null)
            {
                return NotFound(contact);
            }
            if(contact!=null)
            {
                contact.Name=updatedContact.Name;
                contact.Email=updatedContact.Email;
                contact.OrganisationId=updatedContact.OrganisationId;
            }
            return Ok(contact);
        }

        [HttpDelete]
        public ActionResult<List<Contact>> Delete(int id)
        {
            Contact Contact=Contacts.FirstOrDefault(o=>o.Id==id);

            if(Contact==null)
            {
                return StatusCode(404,$"Contact with id '{id}' not found");
            }

            Contacts.Remove(Contact);
            return Ok(Contacts);
        }
    }
}