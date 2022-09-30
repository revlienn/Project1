using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.Dtos.Contact;
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
        public async Task<ActionResult<ServiceResponse<GetContactDto>>> AddNew(AddContactDto newContact)
        {   
            var addedContact=await _contactService.AddNew(newContact);
            if(addedContact.Success==false)
            {
                return Conflict(addedContact);
            }
            return Ok(addedContact);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetContactDto>>> Update(UpdateContactDto updatedContact)
        {
            var checkContact=await _contactService.Update(updatedContact);
            if(checkContact.Data==null)
            {
                return StatusCode(404,"Id Not Found");
            }
            return Ok(checkContact);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetContactDto>>>> Delete(int id)
        {
            var toDelete=await _contactService.Delete(id);
            if(toDelete.Data==null)
            {
                return StatusCode(404,"Id Not Found");
            }
            return Ok(toDelete);
        }

        [HttpGet("All")]
        public async Task<ActionResult<ServiceResponse<List<GetContactDto>>>> GetAll()
        {
            return Ok(await _contactService.GetAll());
        }

        [HttpGet("ById")]
        public async Task<ActionResult<ServiceResponse<GetContactDto>>> GetById(int id)
        {
            var checkId=await _contactService.GetById(id);
            if(checkId.Data==null)
            {
                return NotFound(checkId);
            }
            return Ok(checkId);
        }

        [HttpGet("ByName")]
        public async Task<ActionResult<ServiceResponse<List<GetContactDto>>>> GetByName(string name)
        {
            var matchedContacts=await _contactService.GetByName(name);
            if (matchedContacts.Data==null)
            {
                return StatusCode(404,"No matching users");
            }
            return matchedContacts;
        }

    }
}
