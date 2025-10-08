using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceProject.BL.Services
{
    public class OrderManager:CrudManager<Order, OrderViewModel, OrderCreateViewModel, OrderUpdateViewModel>,
        IOrderService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAddressService _addressService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly BasketManager _basketManager;
        private readonly IDiscountCodeService _discountCodeService;


        public OrderManager(IRepository<Order> repository, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IAddressService addressService, IOrderDetailService orderDetailService, BasketManager basketManager, IDiscountCodeService discountCodeService) : base(repository, mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _addressService = addressService;
            _orderDetailService = orderDetailService;
            _basketManager = basketManager;
            _discountCodeService = discountCodeService;
        }

        public async Task<OrderCreateViewModel> GetUserAndAddressViewModel(OrderCreateViewModel model)
        {
            var currentUser = _httpContextAccessor.HttpContext?.User;

            if (currentUser != null && currentUser.Identity!.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(currentUser.Identity.Name!);

                if (user != null)
                {
                    model.AppUserId = user.Id;
                    model.Email = user.Email!;

                    var addressViewModel = await _addressService.GetAsync(predicate:
                         x => x.AppUserId == user.Id && x.IsDefault && !x.IsDeleted);

                    if (addressViewModel != null)
                    {
                        //model.AddressViewModel= addressViewModel;
                        model.AddressCreateViewModel = new AddressCreateViewModel()
                        {
                            Adress = addressViewModel.Adress!,
                            FirstName = addressViewModel.FirstName!,
                            LastName = addressViewModel.LastName!,
                            Country = addressViewModel.Country!,
                            Company = addressViewModel.Company,
                            City = addressViewModel.City!,
                            Phone = addressViewModel.Phone!,
                            PostalCode = addressViewModel.PostalCode!
                        };
                    }
                }
            }

            return model;
        }

        public override async Task CreateAsync(OrderCreateViewModel model)
        {
            model.OrderDetails = await _orderDetailService.GetOrderDetailCreateViewModels();
            model.OrderStatus = OrderStatus.OnHold;

            var order = Mapper.Map<Order>(model);

            var currentUser = _httpContextAccessor.HttpContext?.User;

            order.DiscountCodeId = model.DiscountCodeId;

            if (currentUser != null && currentUser.Identity!.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(currentUser.Identity.Name!);

                if (user != null)
                {
                    order.AppUserId = user.Id;
                    order.Email = user.Email!;

                    var addressViewModel = await _addressService.GetAsync(predicate:
                         x => x.AppUserId == user.Id && x.IsDefault && !x.IsDeleted);

                    if (addressViewModel != null)
                        order.AddressId = addressViewModel.Id;

                }
            }
            else
            {
                if (model.AddressCreateViewModel != null)
                {
                    var address = await _addressService.CreateAddressAsync(model.AddressCreateViewModel);
                    order.AddressId = address.Id;
                }
            }

            await Repository.CreateAsync(order);
        }

        public async Task<DiscountCodeViewModel> GetDiscount(string discountCode)
        {
            var basket = await _basketManager.GetBasketAsync();

            var discount = await _discountCodeService.GetAsync(predicate:
                    x => x.Code == discountCode && x.IsActive && !x.IsDeleted);

            return discount!;
        }
    }
}
