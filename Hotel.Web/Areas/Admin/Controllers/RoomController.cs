using Hotel.Services;
using Hotel.Utilities;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing.Printing;

namespace Hotel.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoomController : Controller
    {
        private IRoomService _room;
        private IHotelInfo _hotelInfo;
        IWebHostEnvironment _env;

        public RoomController(IRoomService room, IHotelInfo hotelInfo, IWebHostEnvironment env)
        {
            _room = room;
            _hotelInfo = hotelInfo;
            this._env = env;
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
            if (vm.RoomPictureFile != null) 
        {
            ImageOperation image = new ImageOperation(_env);
            string ImageFileName= image.UploadImage(vm);
            vm.PictureURL = ImageFileName;
        }
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
