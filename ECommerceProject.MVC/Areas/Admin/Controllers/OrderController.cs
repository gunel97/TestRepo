using ECommerceProject.BL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.MVC.Areas.Admin.Controllers
{
    public class OrderController : AdminController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllAsync(include: x => 
            x.Include(o => o.OrderDetails).ThenInclude(p=>p.ProductVariant)
            .Include(a=>a.Address)
            .Include(u=>u.AppUser!));
            return View(orders);
        }
    }
}
