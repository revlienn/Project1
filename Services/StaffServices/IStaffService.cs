using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Dtos.Staff;

namespace Project1.Services.StaffServices
{
    public interface IStaffService
    {
        Task<ServiceResponse<List<GetDto>>> GetAll();
        Task<ServiceResponse<GetDto>> GetById(int id);
        Task<ServiceResponse<List<GetDto>>> GetByName(string name);
        Task<ServiceResponse<GetDto>> AddNew(AddDto newStaff);
        Task<ServiceResponse<GetDto>> Update(UpdateDto updatedStaff);
        Task<ServiceResponse<List<GetDto>>> Delete(int id);
    }
}