using Hotel.Services;
using Hotel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ContactController : Controller
    {
        private IContactService _contact;

        public ContactController(IContactService contact)
        {
            _contact = contact;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_contact.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var viewModel = _contact.GetContactById(id);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _contact.GetContactById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ContactViewModel vm)
        {
            _contact.UpdateContact(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _contact.InsertContact(vm);
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
            _contact.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}
