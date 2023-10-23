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
    public class HotelInfoService : IHotelInfo
    {
        private IUnitOfWork _unitOfWork;

        public HotelInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteHotelInfo(int id)
        {
            var model = _unitOfWork.GenericRepository<HotelInfo>().GetById(id);
            _unitOfWork.GenericRepository<HotelInfo>().Delete(model);
            _unitOfWork.save();
        }

        public PageResult<HotelInfoViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new HotelInfoViewModel();
            int totalCount;
            List<HotelInfoViewModel> vmList = new List<HotelInfoViewModel>();

            try
            {
                int ExcludeRecords =(pageSize*pageNumber) - pageSize;
                var modelList=_unitOfWork.GenericRepository<HotelInfo>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount=_unitOfWork.GenericRepository<HotelInfo>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {

                throw;
            }
            var result = new PageResult<HotelInfoViewModel>
            {
                Data= vmList,
                TotalItems= totalCount,
                PageNumber= pageNumber,
                PageSize= pageSize,
            };
            return result;
        }

        public HotelInfoViewModel GetHotelById(int HotelId)
        {
            var model = _unitOfWork.GenericRepository<HotelInfo>().GetById(HotelId);
            var vm= new HotelInfoViewModel(model);
            return vm;
        }

        public void InsertHotelInfo(HotelInfoViewModel hotelInfo)
        {
            var model = new HotelInfoViewModel().ConvertViewModel(hotelInfo);
            _unitOfWork.GenericRepository<HotelInfo>().Add(model);
            _unitOfWork.save();
        }

        public void UpdateHotelInfo(HotelInfoViewModel hotelInfo)
        {
            var model = new HotelInfoViewModel().ConvertViewModel(hotelInfo);
            var ModelById= _unitOfWork.GenericRepository<HotelInfo>().GetById(model.Id);
            ModelById.Name = hotelInfo.Name;
            ModelById.City = hotelInfo.City;
            ModelById.PinCode = hotelInfo.PinCode;
            ModelById.Country = hotelInfo.Country;
            _unitOfWork.GenericRepository<HotelInfo>().Update(ModelById);
            _unitOfWork.save();
        }

        private List<HotelInfoViewModel> ConvertModelToViewModelList(List<HotelInfo> modelList)
        {
            return modelList.Select(x => new HotelInfoViewModel(x)).ToList();
        }
    }
}
