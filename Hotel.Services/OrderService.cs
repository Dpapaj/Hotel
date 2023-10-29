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
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteOrder(int id)
        {
            var model = _unitOfWork.GenericRepository<Order>().GetById(id);
            _unitOfWork.GenericRepository<Order>().Delete(model);
            _unitOfWork.save();
        }

        public PageResult<OrderViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new OrderViewModel();
            int totalCount;
            List<OrderViewModel> vmList = new List<OrderViewModel>();
            try
            {
                int ExludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Order>().GetAll().Skip(ExludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Order>().GetAll().ToList().Count();
                vmList = ConvertModelToViewModelList(modelList);


            }
            catch (Exception)
            {

                throw;
            }
            var result = new PageResult<OrderViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };
            return result;
        }

        private List<OrderViewModel> ConvertModelToViewModelList(List<Order> modelList)
        {
            return modelList.Select(x => new OrderViewModel(x)).ToList();
        }

        public OrderViewModel GetOrderById(int orderId)
        {
            var model = _unitOfWork.GenericRepository<Order>().GetById(orderId);
            var vm = new OrderViewModel(model);
            return vm;
        }

        public void InsertOrder(OrderViewModel orderId)
        {
            var model = new OrderViewModel().ConvertViewModel(orderId);
            _unitOfWork.GenericRepository<Order>().Add(model);
            _unitOfWork.save();
        }

        public void UpdateOrder(OrderViewModel orderId)
        {
            var model = new OrderViewModel().ConvertViewModel(orderId);
            var ModelById = _unitOfWork.GenericRepository<Order>().GetById(model.Id);
            ModelById.Id = orderId.Id;
            ModelById.Number = orderId.Number;
            ModelById.Type = orderId.Type;
            ModelById.StartDate = orderId.StartDate;
            ModelById.EndDate = orderId.EndDate;
            ModelById.Description = orderId.Description;

 

            _unitOfWork.GenericRepository<Order>().Update(ModelById);
            _unitOfWork.save();
        }
    }
}
