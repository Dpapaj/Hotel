using Hotel.Services;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hotel.Web.Areas.Manager.Controllers
{
    [Area("manager")]
    public class TimingController : Controller
    {
        private ITimingService _timingService;

        public TimingController(ITimingService timingService)
        {
            _timingService = timingService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_timingService.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult AddTiming()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTiming(TimingViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _timingService.AddTiming(vm);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while adding the timing.");
                }
            }

            return View(vm);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var viewModel = _timingService.GetTimingById(id);
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _timingService.GetTimingById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(TimingViewModel vm)
        {
            _timingService.UpdateTiming(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int timingId)
        {
            _timingService.DeleteTiming(timingId);
            return RedirectToAction("Index");
        }
    }
}
