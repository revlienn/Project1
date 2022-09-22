using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Services.StaffServices
{
    public class StaffService : IStaffService
    {
        private List<Staff> Staffs=new List<Staff>
        {
            new Staff(),
            new Staff()
            {
                Id=2,
                Name="John Doe",
                Email="johndoe@email.co.uk"
            },
            new Staff()
            {
                Id=3,
                Name="John Smith",
                Email="johnsmith@email.co.uk"
            }
        };

        public async Task<List<Staff>> AddNewStaff(Staff newStaff)
        {
            Staffs.Add(newStaff);
            return Staffs;
        }

        public async Task<List<Staff>> Delete(int id)
        {
            Staff staff=Staffs.FirstOrDefault(s=>s.Id==id);
            if(staff==null)
            {
                return null;
            }
            Staffs.Remove(staff);
            return Staffs;
        }

        public async Task<List<Staff>> GetAllStaffs()
        {
            return Staffs;
        }

        public async Task<Staff> GetStaffById(int id)
        {   
            return Staffs.FirstOrDefault(s=>s.Id==id);
        }

        public async Task<List<Staff>> GetStaffByName(string name)
        {
            var matchingStaff=new List<Staff>();

            foreach(Staff staff in Staffs)
            {
                if(staff.Name.ToLower().Contains(name))
                {
                    matchingStaff.Add(staff);
                }
            }

            return matchingStaff;
        }

        public async Task<Staff> Update(Staff updatedStaff)
        {
            var staff=Staffs.FirstOrDefault(s=>s.Id==updatedStaff.Id);
            staff.Name=updatedStaff.Name;
            staff.Email=updatedStaff.Email;
            return staff;

            /*
            var staff=Staffs.FirstOrDefault(s=>s.Id==updatedStaff.Id);
            if(staff==null)
            {
                return NotFound(staff);
            }
            if(staff!=null)
            {
                staff.Name=updatedStaff.Name;
                staff.Email=updatedStaff.Email;
            }
            return Ok(staff);
            */
        }
    }
}