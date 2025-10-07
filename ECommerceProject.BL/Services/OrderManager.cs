using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        public OrderManager(IRepository<Order> repository, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IAddressService addressService, IOrderDetailService orderDetailService) : base(repository, mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _addressService = addressService;
            _orderDetailService = orderDetailService;
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
                        model.AddressCreateViewModel = new AddressCreateViewModel()
                        {
                            Adress = addressViewModel.Adress!,
                            FirstName = addressViewModel.FirstName!,
                            LastName = addressViewModel.LastName!,
                            Country = addressViewModel.Country,
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

            if(model.AddressCreateViewModel != null)
            {
                var address = await _addressService.CreateAddressAsync( model.AddressCreateViewModel);
                order.AddressId = address.Id;
            }

            await Repository.CreateAsync(order);
        }

        //public async Task<> CreateOrderWithoutUser()
        //{

        //}

        //public async Task<> CreateOrderOfUser()
        //{

        //}

    }
}
