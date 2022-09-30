using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.Dtos.Organisation;
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
        public async Task<ActionResult<ServiceResponse<GetOrganisationDto>>> AddNew(AddOrganisationDto newOrganisation)
        {   
            var addedOrganisation=await _organisationService.AddNew(newOrganisation);
            if(addedOrganisation.Data==null)
            {
                return Conflict(addedOrganisation);
            }
            return Ok(addedOrganisation);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetOrganisationDto>>> Update(UpdateOrganisationDto updatedOrganisation)
        {
            var checkOrganisation=await _organisationService.Update(updatedOrganisation);
            if(checkOrganisation.Data==null)
            {
                return StatusCode(404,"Id Not Found");
            }
            return Ok(checkOrganisation);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetOrganisationDto>>>> Delete(int id)
        {
            var toDelete=await _organisationService.Delete(id);
            if(toDelete.Data==null)
            {
                return StatusCode(404,"Id Not Found");
            }
            return Ok(toDelete);
        }

        [HttpGet("All")]
        public async Task<ActionResult<ServiceResponse<List<GetOrganisationDto>>>> GetAll()
        {
            return Ok(await _organisationService.GetAll());
        }

        [HttpGet("ById")]
        public async Task<ActionResult<ServiceResponse<GetOrganisationDto>>> GetById(int id)
        {
            var checkId=await _organisationService.GetById(id);
            if(checkId.Data==null)
            {
                return NotFound(checkId);
            }
            return Ok(checkId);
        }

        [HttpGet("ByName")]
        public async Task<ActionResult<ServiceResponse<List<GetOrganisationDto>>>> GetByName(string name)
        {
            var matchedOrganisations=await _organisationService.GetByName(name);
            if (matchedOrganisations.Data==null)
            {
                return NotFound(matchedOrganisations);
            }
            return matchedOrganisations;
        }
    }
}