// ProfileController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HotelApp.Models;
using System.Threading.Tasks;

namespace HotelApp.Controllers
{
    [Authorize] // Доступ только для авторизованных пользователей
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // Страница профиля
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Получаем текущего пользователя
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            // Передаем email в представление
            var model = new ProfileViewModel
            {
                Email = user.Email
            };

            return View(model);
        }
    }
}