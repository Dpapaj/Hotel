using Hotel.Models;
using Hotel.Repositories.Interface;
using Hotel.Utilities;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PageResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
            try
            {
                int Excluderecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().Skip(Excluderecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {

                throw;
            }
            var result = new PageResult<ApplicationUserViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };
            return result;
        }

        private List<ApplicationUserViewModel> ConvertModelToViewModelList(List<ApplicationUser> modelList)
        {
            return modelList.Select(x => new ApplicationUserViewModel(x)).ToList();
        }

        public PageResult<ApplicationUserViewModel> GetAllCustomer(int pageNumber, int pageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
            try
            {
                int Excluderecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsManager == false).Skip(Excluderecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsManager == false).ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {

                throw;
            }
            var result = new PageResult<ApplicationUserViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };
            return result;
        }

        public PageResult<ApplicationUserViewModel> GetAllManager(int pageNumber, int pageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
            try
            {
                int Excluderecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x=>x.IsManager==true).Skip(Excluderecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsManager == true).ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {

                throw;
            }
            var result = new PageResult<ApplicationUserViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };
            return result;
        }

    }
}
