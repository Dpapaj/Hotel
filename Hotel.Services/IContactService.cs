using Hotel.Utilities;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public interface IContactService
    {
        PageResult<ContactViewModel> GetAll(int pageNumber, int pageSize);
        ContactViewModel GetContactById(int Contactid);
        void UpdateContact (ContactViewModel contact);
        void DeleteContact (int id);
        void InsertContact (ContactViewModel contact);
    }
}
