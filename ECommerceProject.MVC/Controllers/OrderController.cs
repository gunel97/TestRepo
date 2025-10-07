using AutoMapper;
using ECommerceProject.BL.Services;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ECommerceProject.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly BasketManager _basketManager;
        private readonly IAddressService _addressService;
        private readonly IDiscountCodeService _discountCodeService;
        public OrderController(IOrderService orderService, UserManager<AppUser> userManager, IOrderDetailService orderDetailService, BasketManager basketManager, IAddressService addressService, IDiscountCodeService discountCodeService)
        {
            _orderService = orderService;
            _userManager = userManager;
            _orderDetailService = orderDetailService;
            _basketManager = basketManager;
            _addressService = addressService;
            _discountCodeService = discountCodeService;
        }

        public async Task<IActionResult> Checkout()
        {
            var addressViewModel = new AddressViewModel();

            var model = new OrderCreateViewModel();
            model.OrderDetails = await _orderDetailService.GetOrderDetailCreateViewModels();
            model = await _orderService.GetUserAndAddressViewModel(model);
        //  model.TotalPrice = model.OrderDetails.Sum(x => x.TotalPrice);

            return View(model);
        }

        

        [HttpPost]
        public async Task<IActionResult> Checkout (OrderCreateViewModel model)
        {
            model.OrderDetails = await _orderDetailService.GetOrderDetailCreateViewModels();

            if (!ModelState.IsValid)
            {
                return View(model);
            }         

            if (model.Discount != null)
            {
                var discountCode = await _discountCodeService.GetAsync(predicate:
                     x => x.Code.ToLower() == model.Discount.ToLower() && x.IsActive && !x.IsDeleted);

                if (discountCode == null)
                    ModelState.AddModelError("Aktiv bele kod movcud deyil", nameof(model.Discount));
                else
                    model.TotalPrice -= (model.TotalPrice * discountCode.SalePercentage) / 100;
            }

            await _orderService.CreateAsync(model);
            return RedirectToAction("Index", "Home");
        }

    }
}
