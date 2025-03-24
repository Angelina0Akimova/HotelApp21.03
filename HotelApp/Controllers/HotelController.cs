using HotelApp.Data;
using HotelApp.Data.Service;
using HotelApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelsServece _hotelService;
        public HotelController(IHotelsServece hotelService)
        {
            _hotelService = hotelService; 
        }
        public async Task<IActionResult> Index(string sortCountry)
        {
            var hotels = await _hotelService.GetAll();
            // Отладочная информация: выводим значение sortCountry
            Console.WriteLine($"SortCountry: {sortCountry}");
            // Если выбрана конкретная страна, фильтруем отели
            if (!string.IsNullOrEmpty(sortCountry))
            {
                hotels = hotels.Where(h => h.Country == sortCountry).ToList();
            }

            // Передаем список стран в представление
            ViewBag.Countries = Hotels.AllowedCountries;
            return View(hotels);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Hotels hotels)
        {
            if (!Hotels.AllowedCountries.Contains(hotels.Country))
            {
                ModelState.AddModelError("Country", "Выбранная страна не поддерживается.");
            }

            if (ModelState.IsValid)
            {
                await _hotelService.Add(hotels);
                return RedirectToAction("Index");
            }

            return View(hotels);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _hotelService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
