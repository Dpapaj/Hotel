using Hotel.Utilities;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public interface IOrderService
    {
        PageResult<OrderViewModel> GetAll(int pageNumber, int pageSize);
        OrderViewModel GetOrderById(int orderId);
        void UpdateOrder(OrderViewModel orderId);
        void InsertOrder(OrderViewModel orderId);
        void DeleteOrder(int id);
    }
}
