using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Dtos.Staff;

namespace Project1.Services.StaffServices
{
    public interface IStaffService
    {
        Task<ServiceResponse<List<GetStaffDto>>> GetAll();
        Task<ServiceResponse<GetStaffDto>> GetById(int id);
        Task<ServiceResponse<List<GetStaffDto>>> GetByName(string name);
        Task<ServiceResponse<GetStaffDto>> AddNew(AddStaffDto newStaff);
        Task<ServiceResponse<GetStaffDto>> Update(UpdateStaffDto updatedStaff);
        Task<ServiceResponse<List<GetStaffDto>>> Delete(int id);
    }
}