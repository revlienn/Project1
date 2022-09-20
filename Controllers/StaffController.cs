using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project1.Controllers
{
    [ApiController]
    [Route("Staff")]
    public class StaffController:ControllerBase
    {

        private List<Staff> Staffs=new List<Staff>
        {
            new Staff(),
            new Staff()
            {
                Id=2,
                Name="John Doe",
                Email="johndoe@email.co.uk"
            }
        };


        [HttpGet("Id")]
        public ActionResult<Staff> GetStaffById(int Id)
        {
            return Ok(Staffs.FirstOrDefault(c=>c.Id==Id));
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Staff>> GetAllStaffs()
        {
            return Ok(Staffs);
        }
    }
}