using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project1.Dtos.Contact;
using Project1.Dtos.Organisation;
using Project1.Dtos.Project;
using Project1.Dtos.Staff;

namespace Project1
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddStaffDto,Staff>();
            CreateMap<Staff,GetStaffDto>();

            CreateMap<AddContactDto,Contact>();
            //CreateMap<UpdateContactDto,Contact>();
            CreateMap<Contact,GetContactDto>();

            CreateMap<AddProjectDto,Project>();
            CreateMap<Project,GetProjectDto>();

            CreateMap<AddOrganisationDto,Organisation>();
            CreateMap<Organisation,GetOrganisationDto>();
            
        }
    }
}