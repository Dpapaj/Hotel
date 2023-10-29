using Hotel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.Customer.Controllers
{
    [Area("customer")]
    public class CustomerController : Controller
    {
        private IRoomService _room;

        public CustomerController(IRoomService room)
        {
            _room = room;
        }

        public IActionResult Index()
        {
            return View(_room.GetAllR());
        }
    }
}
