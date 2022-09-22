using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Services.StaffServices
{
    public interface IStaffService
    {
        Task<List<Staff>> AddNewStaff(Staff newStaff);
        Task<Staff> Update(Staff updatedStaff);
        Task<List<Staff>> Delete(int id);
        Task<List<Staff>> GetAllStaffs();
        Task<Staff> GetStaffById(int id);
        Task<List<Staff>> GetStaffByName(string name);
    }
}