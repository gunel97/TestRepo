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
        private readonly IOrderService _orderManager;
        private readonly IOrderDetailService _orderDetailService;
        private readonly BasketManager _basketManager;
        private readonly IAddressService _addressService;
        private readonly IDiscountCodeService _discountCodeService;
        public OrderController(IOrderService orderService, UserManager<AppUser> userManager, IOrderDetailService orderDetailService, BasketManager basketManager, IAddressService addressService, IDiscountCodeService discountCodeService)
        {
            _orderManager = orderService;
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

            var basketViewModel = await _basketManager.GetBasketAsync();

            model.BasketViewModel = basketViewModel;

            model.OrderDetails = await _orderDetailService.GetOrderDetailCreateViewModels();
            model = await _orderManager.GetUserAndAddressViewModel(model);
            model.TotalPrice = basketViewModel.TotalPrice;

            return View(model);
        }

        

        [HttpPost]
        public async Task<IActionResult> Checkout (OrderCreateViewModel model)
        {
            if(model.AddressCreateViewModel == null)
            {
                ModelState.AddModelError("", "Unvan qeyd edilmeyib");

                return View(model);
            }

            if (model.AcceptTermsConditions == false)
            {
                ModelState.AddModelError("", "Terms and conditions must be accepted");

                return View(model);
            }

            var basketViewModel = await _basketManager.GetBasketAsync();
            model.OrderDetails =await _orderDetailService.GetOrderDetailCreateViewModels();

            model.BasketViewModel= basketViewModel;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Discount!=null && model.HasAppliedDiscount)
            {
                var discount = await _orderManager.GetDiscount(model.Discount);

                if (discount != null)
                {
                    model.TotalPrice -= (model.TotalPrice * discount.SalePercentage) / 100;
                    model.DiscountCodeId = discount.Id;
                }
            }

            await _orderManager.CreateAsync(model);
            _basketManager.CleanBasket();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> ApplyDiscount(string discountCode)
        {
            var discount = await _orderManager.GetDiscount(discountCode);
            var result = 0;

            if (discount != null)
            {
                result = discount.SalePercentage;
            }

            return Json(new
            {
                success = true,
                result,
            });
        }

    }
}
