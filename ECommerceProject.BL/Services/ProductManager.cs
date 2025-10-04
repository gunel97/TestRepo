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
    public class ProductManager :CrudManager<Product, ProductViewModel, ProductCreateViewModel, ProductUpdateViewModel>,
        IProductService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWishlistItemService _wishlistService;

        public ProductManager(IRepository<Product> repository, IMapper mapper, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, IWishlistItemService wishlistService)
            : base(repository, mapper)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _wishlistService = wishlistService;
        }


        //public void CheckProduct(int id)
        //{
        //    var currentUser = _httpContextAccessor.HttpContext?.User;

        //    if(currentUser!=null && currentUser.Identity!.IsAuthenticated)
        //    {
        //        var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //        var listItems = _wishlistService.get
        //    }
        //}
    }
}
