using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Services.ContactServices
{
    public interface IContactService
    {
        Task<ServiceResponse<List<Contact>>> GetAll();
        Task<ServiceResponse<Contact>> GetById(int id);
        Task<ServiceResponse<List<Contact>>> GetByName(string name);
        Task<ServiceResponse<Contact>> AddNew(Contact newContact);
        Task<ServiceResponse<Contact>> Update(Contact updatedContact);
        Task<ServiceResponse<List<Contact>>> Delete(int id);

    }
}