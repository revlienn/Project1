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

        //public IMapper Mapper { get; }

        public async Task<ServiceResponse<GetStaffDto>> AddNew(AddStaffDto newStaff)
        {
            var serviceResponse=new ServiceResponse<GetStaffDto>();
            var addedStaff=_mapper.Map<Staff>(newStaff);

            try
                {
                    addedStaff.Id=Staffs.Max(c=>c.Id)+1;
                    Staffs.Add(addedStaff);
                    serviceResponse.Data=_mapper.Map<GetStaffDto>(addedStaff);
                    serviceResponse.Message=$"User {addedStaff.Name} successfully added.";
                    
                }
            catch(Exception ex)
                {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
                }
            return serviceResponse;

            // will automate in efcore
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
            
        }

        public async Task<ServiceResponse<GetStaffDto>> Update(UpdateStaffDto updatedStaff)
        {
            var serviceResponse=new ServiceResponse<GetStaffDto>();

            try
            {
                var checkStaff=Staffs.FirstOrDefault(c=>c.Id==updatedStaff.Id);
                if(checkStaff!=null)
                {
                    checkStaff.Name=updatedStaff.Name;
                    checkStaff.Email=updatedStaff.Email;
                    serviceResponse.Data=_mapper.Map<GetStaffDto>(checkStaff);
                }
                else
                {
                    serviceResponse.Data=null;
                    serviceResponse.Success=false;
                    serviceResponse.Message=$"Id {updatedStaff.Id} Not Found";
                }

            }
            catch(Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStaffDto>>> Delete(int id)
        {
            var serviceResponse=new ServiceResponse<List<GetStaffDto>>();
            var toDelete=Staffs.FirstOrDefault(c=>c.Id==id);

            try
            {
                if(toDelete!=null)
                {
                    Staffs.Remove(toDelete);
                    serviceResponse.Data=Staffs.Select(c=>_mapper.Map<GetStaffDto>(c)).ToList();
                }
                else
                {
                    serviceResponse.Data=null;
                    serviceResponse.Success=false;
                    serviceResponse.Message=$"Id {id} Not Found";
                }
            }
            catch(Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStaffDto>>> GetAll()
        {
            var serviceResponse=new ServiceResponse<List<GetStaffDto>>();

            serviceResponse.Data=Staffs.Select(s=>_mapper.Map<GetStaffDto>(s)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStaffDto>> GetById(int id)
        {
            var serviceResponse=new ServiceResponse<GetStaffDto>();
            var checkId=Staffs.FirstOrDefault(c=>c.Id==id);

            try
            {
                if(checkId!=null)
                {
                    serviceResponse.Data=_mapper.Map<GetStaffDto>(checkId);
                }
                else
                {
                    serviceResponse.Data=null;
                    serviceResponse.Success=false;
                    serviceResponse.Message=$"Id {id} Not Found";
                }
            }
            catch(Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStaffDto>>> GetByName(string name)
        {
            var serviceResponse=new ServiceResponse<List<GetStaffDto>>();

            var matchedStaffs=new List<Staff>();
            foreach(Staff staff in Staffs)
            {
                if(staff.Name.ToLower().Contains(name.ToLower()))
                {
                    matchedStaffs.Add(staff);
                }
            }

            try
            {
                if(matchedStaffs.Count>=1)
                {
                    serviceResponse.Data=matchedStaffs.Select(mc=>_mapper.Map<GetStaffDto>(mc)).ToList();
                }
                else
                {
                    serviceResponse.Data=null;
                    serviceResponse.Success=false;
                    serviceResponse.Message=$"Name containing {name} Not Found";
                }
                
            }
            catch(Exception ex)
            {
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
            }
            return serviceResponse;
        }

        
    }
}