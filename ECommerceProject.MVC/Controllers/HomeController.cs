using System.Diagnostics;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _homeService.GetHomeViewModelAsync();

            return View(model);
        }

      
    }
}
