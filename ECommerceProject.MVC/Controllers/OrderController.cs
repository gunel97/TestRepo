using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;

        public OrderController(IOrderService orderService, UserManager<AppUser> userManager, IOrderDetailService orderDetailService)
        {
            _orderService = orderService;
            _userManager = userManager;
            _orderDetailService = orderDetailService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


    }
}
