using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project1.Dtos.Staff;

namespace Project1.Services.StaffServices
{
    public class StaffService : IStaffService
    {

        private readonly IMapper _mapper;
        public StaffService(IMapper mapper)
        {
            _mapper = mapper;
        }
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

        public IMapper Mapper { get; }

        public async Task<ServiceResponse<GetDto>> AddNew(AddDto newStaff)
        {
            var serviceResponse=new ServiceResponse<GetDto>();

            // automate in efcore
            /*
            var checkStaff=Staffs.FirstOrDefault(c=>c.Id==newStaff.Id); 

            if(checkStaff!=null)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Id {newStaff.Id} has been assigned to a different user";
                return serviceResponse;
            }
            */

            var addedStaff=_mapper.Map<Staff>(newStaff);
            addedStaff.Id=Staffs.Max(c=>c.Id)+1;

            Staffs.Add(addedStaff);

            serviceResponse.Data=_mapper.Map<GetDto>(addedStaff);

            serviceResponse.Message=$"User {newStaff.Name} successfully added.";

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDto>>> GetAll()
        {
            var serviceResponse=new ServiceResponse<List<GetDto>>();

            serviceResponse.Data=Staffs.Select(s=>_mapper.Map<GetDto>(s)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDto>> GetById(int id)
        {
            var serviceResponse=new ServiceResponse<GetDto>();

            var checkId=Staffs.FirstOrDefault(c=>c.Id==id);
            if(checkId==null)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Id {id} Not Found";
                return serviceResponse;
            }

            serviceResponse.Data=_mapper.Map<GetDto>(checkId);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDto>>> GetByName(string name)
        {
            var serviceResponse=new ServiceResponse<List<GetDto>>();

            var matchedStaffs=new List<Staff>();

            foreach(Staff staff in Staffs)
            {
                if(staff.Name.ToLower().Contains(name))
                {
                    matchedStaffs.Add(staff);
                }
            }
            if(matchedStaffs.Count==0)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Name containing {name} Not Found";
                return serviceResponse;
            }
            
            serviceResponse.Data=matchedStaffs.Select(s=>_mapper.Map<GetDto>(s)).ToList();
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDto>> Update(UpdateDto updatedStaff)
        {
            var serviceResponse=new ServiceResponse<GetDto>();

            try
            {
                var checkStaff=Staffs.FirstOrDefault(c=>c.Id==updatedStaff.Id);
                if(checkStaff==null)
                    {
                        serviceResponse.Data=null;
                        serviceResponse.Success=false;
                        serviceResponse.Message=$"Id {updatedStaff.Id} Not Found";
                        return serviceResponse;
                    }
                checkStaff.Name=updatedStaff.Name;
                checkStaff.Email=updatedStaff.Email;

                serviceResponse.Data=_mapper.Map<GetDto>(checkStaff);

            }
            catch(Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
            }

            return serviceResponse;

            /*
            if(checkStaff==null)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Id {updatedStaff.Id} Not Found";
                return serviceResponse;
            }
            checkStaff.Name=updatedStaff.Name;
            checkStaff.Email=updatedStaff.Email;

            serviceResponse.Data=_mapper.Map<GetDto>(checkStaff);
            
            return serviceResponse;
            */
        }

        public async Task<ServiceResponse<List<GetDto>>> Delete(int id)
        {
            var serviceResponse=new ServiceResponse<List<GetDto>>();

            var toDelete=Staffs.FirstOrDefault(c=>c.Id==id);

            if(toDelete==null)
            {
                serviceResponse.Data=null;
                serviceResponse.Success=false;
                serviceResponse.Message=$"Id {id} Not Found";
                return serviceResponse;
            }
            Staffs.Remove(toDelete);

            serviceResponse.Data=Staffs.Select(s=>_mapper.Map<GetDto>(s)).ToList();

            return serviceResponse;
        }
    }
}