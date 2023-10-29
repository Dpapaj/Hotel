using Hotel.Services;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.Customer.Controllers
{
    [Area("customer")]
    public class OrderController : Controller
    {
        private IOrderService _order;

        public OrderController(IOrderService order)
        {
            _order = order;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel vm)
        {
            _order.InsertOrder(vm);
            return RedirectToAction("Index");
        }
    }
}
