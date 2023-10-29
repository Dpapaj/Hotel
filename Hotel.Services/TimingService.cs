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
    public class TimingService : ITimingService
    {
        private IUnitOfWork _unitOfWork;

        public TimingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTiming(TimingViewModel timing)
        {
            var model =new TimingViewModel().ConvertViewModel(timing);
            _unitOfWork.GenericRepository<Timing>().Add(model);
            _unitOfWork.save();
        }

        public void DeleteTiming(int Id)
        {
            var model = _unitOfWork.GenericRepository<Timing>().GetById(Id);
            _unitOfWork.GenericRepository<Timing>().Delete(model);
            _unitOfWork.save();
        }

        public PageResult<TimingViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new TimingViewModel();
            int totalCount;
            List<TimingViewModel> vmList = new List<TimingViewModel>();
            try
            {
                int ExludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Timing>().GetAll().Skip(ExludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Timing>().GetAll().ToList().Count();
                vmList = ConvertModelToViewModelList(modelList);


            }
            catch (Exception)
            {

                throw;
            }
            var result = new PageResult<TimingViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };
            return result;
        }

        private List<TimingViewModel> ConvertModelToViewModelList(List<Timing> modelList)
        {
            return modelList.Select(x => new TimingViewModel(x)).ToList();
        }

        public IEnumerable<TimingViewModel> GetAll()
        {
            var TimingList=_unitOfWork.GenericRepository<Timing>().GetAll().ToList();
            var vmList = ConvertModelToViewModelList(TimingList);
            return vmList;
        }

        public TimingViewModel GetTimingById(int id)
        {
            var model = _unitOfWork.GenericRepository<Timing>().GetById(id);
            var vm = new TimingViewModel(model);
            return vm;
        }

        public void UpdateTiming(TimingViewModel timing)
        {
            var model = new TimingViewModel().ConvertViewModel(timing);
            var ModelById = _unitOfWork.GenericRepository<Timing>().GetById(model.Id);
            ModelById.Status = model.Status;
            ModelById.MornigShiftStartTime = model.MornigShiftStartTime;
            ModelById.MornigShiftEndtTime = model.MornigShiftEndtTime;
            ModelById.AfternoonShiftStartTime = model.AfternoonShiftStartTime;
            ModelById.AfternoonShiftEndTime = model.AfternoonShiftEndTime;

            _unitOfWork.GenericRepository<Timing>().Update(ModelById);
            _unitOfWork.save();
        }
    }
}
