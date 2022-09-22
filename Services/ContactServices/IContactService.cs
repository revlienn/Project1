using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(int id);
        Task<List<Contact>> GetByName(string name);
        Task<Contact> AddNew(Contact newContact);
        Task<Contact> Update(Contact updatedContact);
        Task<List<Contact>> Delete(int id);

    }
}