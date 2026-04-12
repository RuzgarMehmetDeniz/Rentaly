using Microsoft.AspNetCore.Mvc;
using Rentaly.Businesslayer.Abstract;
using Rentaly.EntityLayer.Entities;

namespace Rentaly.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title1 = "Ana Sayfa";
            ViewBag.Title2 = "İletişim Yönetimi";
            ViewBag.Title3 = "İletişim Listesi";
            var values = await _contactService.TGetListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(Contact contact)
        {
            await _contactService.TInsertAsync(contact);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var value = await _contactService.TGetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(Contact contact)
        {
            await _contactService.TUpdateAsync(contact);
            return RedirectToAction("Index");
        }
    }
}