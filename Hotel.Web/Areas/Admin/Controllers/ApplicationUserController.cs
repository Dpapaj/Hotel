using Hotel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ApplicationUserController : Controller
    {
        private IApplicationUserService _userService;

        public ApplicationUserController(IApplicationUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int pageNumber=1,int pageSize=10)
        {
            return View(_userService.GetAll(pageNumber,pageSize));
        }
        public IActionResult AllManagersIndex(int pageNumber = 1, int pageSize = 10)
        {
            return View(_userService.GetAllManager(pageNumber, pageSize));
        }
        public IActionResult AllCutomersIndex(int pageNumber = 1, int pageSize = 10)
        {
            return View(_userService.GetAllCustomer(pageNumber, pageSize));
        }
    }
}
