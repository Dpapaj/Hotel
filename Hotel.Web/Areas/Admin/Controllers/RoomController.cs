using Hotel.Services;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoomController : Controller
    {
        private IRoomService _room;

        public RoomController(IRoomService room)
        {
            _room = room;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_room.GettAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var viewModel = _room.GetRoomId(id);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _room.GetRoomId(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(RoomViewModel vm)
        {
            _room.UpdateRoom(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomViewModel vm)
        {
            _room.InsertRoom(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _room.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
}
