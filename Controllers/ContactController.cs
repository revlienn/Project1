using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.Services.ContactServices;

namespace Project1.Controllers
{
    [ApiController]
    [Route("Contact")]
    public class ContactController:ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> AddNew(Contact newContact)
        {   
            var addedContact=await _contactService.AddNew(newContact);
            if(addedContact==null)
            {
                return StatusCode(409,"Id already exists");
            }
            return Ok(addedContact);
        }

        [HttpPut]
        public async Task<ActionResult<Contact>> Update(Contact updatedContact)
        {
            var checkContact=await _contactService.Update(updatedContact);
            if(checkContact==null)
            {
                return StatusCode(404,"Id Not Found");
            }
            return Ok(checkContact);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Contact>>> Delete(int id)
        {
            var toDelete=await _contactService.Delete(id);
            if(toDelete==null)
            {
                return StatusCode(404,"Id Not Found");
            }
            return Ok(toDelete);
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<Contact>>> GetAll()
        {
            return Ok(await _contactService.GetAll());
        }

        [HttpGet("ById")]
        public async Task<ActionResult<Contact>> GetById(int id)
        {
            var checkId=await _contactService.GetById(id);
            if(checkId==null)
            {
                return NotFound(checkId);
            }
            return Ok(checkId);
        }

        [HttpGet("ByName")]
        public async Task<ActionResult<List<Contact>>> GetByName(string name)
        {
            var matchedContacts=await _contactService.GetByName(name);
            if (matchedContacts==null)
            {
                return StatusCode(404,"No matching users");
            }
            return matchedContacts;
        }

    }
}
