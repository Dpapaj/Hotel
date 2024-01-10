using Hotel.Services;
using Hotel.Utilities;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HotelController : Controller
    {
        private IHotelInfo _hotelInfo;

        public HotelController(IHotelInfo hotelInfo)
        {
            _hotelInfo = hotelInfo;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_hotelInfo.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var viewModel = _hotelInfo.GetHotelById(id);
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _hotelInfo.GetHotelById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(HotelInfoViewModel vm)
        {
            _hotelInfo.UpdateHotelInfo(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HotelInfoViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _hotelInfo.InsertHotelInfo(vm);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the data.");
                }
            }
            return View(vm);
        }


        public IActionResult Delete(int id)
        {
            _hotelInfo.DeleteHotelInfo(id);
            return RedirectToAction("Index");
        }
    }
}
