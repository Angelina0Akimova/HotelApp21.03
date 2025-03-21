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
        public async Task<IActionResult> Index()
        {
            var hotels = await _hotelService.GetAll();
            return View(hotels);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Hotels hotels)
        {
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
