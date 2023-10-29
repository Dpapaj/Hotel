using Hotel.Models;
using Hotel.Repositories.Interface;
using Hotel.Utilities;
using Hotel.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public class RoomService : IRoomService
    {
        private IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteRoom(int id)
        {
            var model=_unitOfWork.GenericRepository<Room>().GetById(id);
            _unitOfWork.GenericRepository<Room>().Delete(model);
            _unitOfWork.save();
        }

        public RoomViewModel GetRoomId(int Roomid)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(Roomid);
            var vm = new RoomViewModel(model);
            return vm;
        }

        public PageResult<RoomViewModel> GettAll(int pageNumber, int pageSize)
        {
            var vm= new RoomViewModel();
            int totalCount;
            List<RoomViewModel> vmList=new List<RoomViewModel>();
            try
            {
                int ExludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList=_unitOfWork.GenericRepository<Room>().GetAll(includeProperties:"Hotel").Skip(ExludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Room>().GetAll().ToList().Count();
                vmList = ConvertModelToViewModelList(modelList);


            }
            catch (Exception)
            {

                throw;
            }
            var result = new PageResult<RoomViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };
            return result;
        }

        public void InsertRoom(RoomViewModel Room)
        {
            var model= new RoomViewModel().ConvertViewModel(Room);
            _unitOfWork.GenericRepository<Room>().Add(model);
            _unitOfWork.save();
        }

        public void UpdateRoom(RoomViewModel Room)
        {
            var model = new RoomViewModel().ConvertViewModel(Room);
            var ModelById = _unitOfWork.GenericRepository<Room>().GetById(model.Id);
            ModelById.Type = Room.Type;
            ModelById.RoomNumber = Room.RoomNumber;
            ModelById.StatusR = Room.StatusR;
            ModelById.Description = Room.Description;
            ModelById.PictureURL = Room.PictureURL;
            ModelById.RoomPrice = Room.RoomPrice;
            ModelById.HotelId = Room.HotelInfoId;
            ModelById.WIFI=Room.WIFI;
            ModelById.AC=Room.AC;
            ModelById.Bathroom=Room.Bathroom;

            _unitOfWork.GenericRepository<Room>().Update(ModelById);
            _unitOfWork.save();

            
        }
        public IEnumerable<RoomViewModel> GetAllR()
        {
            var RoomList = _unitOfWork.GenericRepository<Room>().GetAll().ToList();
            var vmList = ConvertModelToViewModelList(RoomList);
            return vmList;
        }
        private List<RoomViewModel> ConvertModelToViewModelList(List<Room> modelList)
        {
            return modelList.Select(x => new RoomViewModel(x)).ToList();
        }
    }
}
