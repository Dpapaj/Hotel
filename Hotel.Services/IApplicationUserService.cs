using Hotel.Utilities;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public interface IApplicationUserService
    {
        PageResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize);
        PageResult<ApplicationUserViewModel> GetAllManager(int pageNumber, int pageSize);
        PageResult<ApplicationUserViewModel> GetAllCustomer(int pageNumber, int pageSize);
        PageResult<ApplicationUserViewModel> SearchManager(int pageNumber, int pageSize, string Spicility=null);
    }
}
