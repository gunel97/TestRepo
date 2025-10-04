using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Security.Claims;

namespace ECommerceProject.BL.Services
{
    public class WishlistItemManager: 
        CrudManager<WishlistItem, WishlistItemViewModel, WishlistItemCreateViewModel, WishlistItemUpdateViewModel>,
        IWishlistItemService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WishlistItemManager(IRepository<WishlistItem> repository, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
            : base(repository, mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<WishlistItemViewModel> CheckProduct(string userId, int id)
        {
            var item = await Repository.GetAsync(predicate: x=>x.AppUserId == userId && x.ProductId==id);

            if (item == null)
                return null!;

            var itemViewModel = Mapper.Map<WishlistItemViewModel>(item);

            return itemViewModel; 
        }

    }
}
