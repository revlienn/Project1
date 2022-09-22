using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IStaffService staffService;


        [HttpPost]
        public async Task<ActionResult<List<Staff>>> AddNewStaff(Staff newStaff)
        {
            return Ok(await _staffService.AddNewStaff(newStaff));
        }

        [HttpPut]
        public async Task<ActionResult<Staff>> Update(Staff updatedStaff)
        {
            return Ok(await _staffService.Update(updatedStaff));
        }

        [HttpDelete]
        public async Task<ActionResult<List<Staff>>> Delete(int id)
        {
            return Ok(await _staffService.Delete(id));
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<Staff>>> GetAllStaffs()
        {
            return Ok(await _staffService.GetAllStaffs());
        }

        [HttpGet("ById")]
        public async Task<ActionResult<Staff>> GetStaffById(int id)
        {
            return Ok (await _staffService.GetStaffById(id));
        }

        [HttpGet("ByName")]
        public async Task<ActionResult<List<Staff>>> GetStaffByName (string name)
        {
            return Ok(await _staffService.GetStaffByName(name));
        }


    }
}

/*
if(modifiedStaff==null)
            {
                return StatusCode(404,"Operation Not Completed. Wrong User Id.");

            }
*/