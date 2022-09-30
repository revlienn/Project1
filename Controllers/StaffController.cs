using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.Dtos.Staff;
using Project1.Services.StaffServices;

namespace Project1.Controllers
{
    [ApiController]
    [Route("Staff")]
    public class StaffController:ControllerBase
    {

        private readonly IStaffService _staffService;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetStaffDto>>> AddNew(AddStaffDto newStaff)
        {   
            var addedStaff=await _staffService.AddNew(newStaff);
            if(addedStaff.Success==false)
            {
                return Conflict(addedStaff);
            }
            return Ok(addedStaff);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetStaffDto>>> Update(UpdateStaffDto updatedStaff)
        {
            var checkStaff=await _staffService.Update(updatedStaff);
            if(checkStaff.Data==null)
            {
                return StatusCode(404,"Id Not Found");
            }
            return Ok(checkStaff);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetStaffDto>>>> Delete(int id)
        {
            var toDelete=await _staffService.Delete(id);
            if(toDelete.Data==null)
            {
                return StatusCode(404,"Id Not Found");
            }
            return Ok(toDelete);
        }

        [HttpGet("All")]
        public async Task<ActionResult<ServiceResponse<List<GetStaffDto>>>> GetAll()
        {
            return Ok(await _staffService.GetAll());
        }

        [HttpGet("ById")]
        public async Task<ActionResult<ServiceResponse<GetStaffDto>>> GetById(int id)
        {
            var checkId=await _staffService.GetById(id);
            if(checkId.Data==null)
            {
                return NotFound(checkId);
            }
            return Ok(checkId);
        }

        [HttpGet("ByName")]
        public async Task<ActionResult<ServiceResponse<List<GetStaffDto>>>> GetByName(string name)
        {
            var matchedStaffs=await _staffService.GetByName(name);
            if (matchedStaffs.Data==null)
            {
                return StatusCode(404,"No matching users");
            }
            return matchedStaffs;
        }


    }
}

/*
if(modifiedStaff==null)
            {
                return StatusCode(404,"Operation Not Completed. Wrong User Id.");

            }
*/