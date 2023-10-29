using Hotel.Models;
using Hotel.Services;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.Manager.Controllers
{
    [Area("manager")]
    public class ManagerController : Controller
    {
        private IOrderService _order;

        public ManagerController(IOrderService order)
        {
            _order = order;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_order.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var viewModel = _order.GetOrderById(id);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _order.GetOrderById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(OrderViewModel vm)
        {
            _order.UpdateOrder(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _order.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}
