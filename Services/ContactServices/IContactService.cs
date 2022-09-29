using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Dtos.Contact;

namespace Project1.Services.ContactServices
{
    public interface IContactService
    {
        Task<ServiceResponse<List<GetContactDto>>> GetAll();
        Task<ServiceResponse<GetContactDto>> GetById(int id);
        Task<ServiceResponse<List<GetContactDto>>> GetByName(string name);
        Task<ServiceResponse<GetContactDto>> AddNew(AddContactDto newContact);
        Task<ServiceResponse<GetContactDto>> Update(UpdateContactDto updatedContact);
        Task<ServiceResponse<List<GetContactDto>>> Delete(int id);

    }
}