using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rentaly.Businesslayer.Abstract;
using Rentaly.DtoLayer.CustomerDtos;

namespace Rentaly.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CustomerList()
        {
            ViewBag.Title1 = "Ana Sayfa";
            ViewBag.Title2 = "Müşteri Yönetimi";
            ViewBag.Title3 = "Müşteri Listesi";
            var values = await _customerService.TGetListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCustomer() => View();

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            await _customerService.TInsertAsync(createCustomerDto);
            TempData["Success"] = "Müşteri başarıyla eklendi.";
            return RedirectToAction("CustomerList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            var value = await _customerService.TGetByIdAsync(id);
            var model = _mapper.Map<UpdateCustomerDto>(value);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            await _customerService.TUpdateAsync(updateCustomerDto);
            TempData["Success"] = "Müşteri başarıyla güncellendi.";
            return RedirectToAction("CustomerList");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCustomer(int id) // Buradaki isim 'id' olmalı
        {
            await _customerService.TDeleteAsync(id);
            return RedirectToAction("CustomerList"); // Burası liste sayfanın adı olmalı
        }
    }
}