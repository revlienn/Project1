using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.Services.OrganisationServices;

namespace Project1.Controllers
{
    [ApiController]
    [Route("Organisation")]
    public class OrganisationController:ControllerBase
    {
        private readonly IOrganisationService _organisationService;

        public OrganisationController(IOrganisationService organisationService)
        {
            _organisationService = organisationService;
        }

        [HttpPost]
        public async Task<ActionResult<Organisation>> AddNew(Organisation newOrganisation)
        {   
            var addedOrganisation=await _organisationService.AddNew(newOrganisation);
            if(addedOrganisation==null)
            {
                return StatusCode(409,"Id already exists");
            }
            return Ok(addedOrganisation);
        }

        [HttpPut]
        public async Task<ActionResult<Organisation>> Update(Organisation updatedOrganisation)
        {
            var checkOrganisation=await _organisationService.Update(updatedOrganisation);
            if(checkOrganisation==null)
            {
                return StatusCode(404,"Id Not Found");
            }
            return Ok(checkOrganisation);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Organisation>>> Delete(int id)
        {
            var toDelete=await _organisationService.Delete(id);
            if(toDelete==null)
            {
                return StatusCode(404,"Id Not Found");
            }
            return Ok(toDelete);
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<Organisation>>> GetAll()
        {
            return Ok(await _organisationService.GetAll());
        }

        [HttpGet("ById")]
        public async Task<ActionResult<Organisation>> GetById(int id)
        {
            var checkId=await _organisationService.GetById(id);
            if(checkId==null)
            {
                return NotFound(checkId);
            }
            return Ok(checkId);
        }

        [HttpGet("ByName")]
        public async Task<ActionResult<List<Organisation>>> GetByName(string name)
        {
            var matchedOrganisations=await _organisationService.GetByName(name);
            if (matchedOrganisations==null)
            {
                return StatusCode(404,"No matching users");
            }
            return matchedOrganisations;
        }
    }
}