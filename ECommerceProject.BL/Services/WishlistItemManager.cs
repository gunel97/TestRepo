using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace ECommerceProject.BL.Services
{
    public class WishlistItemManager: 
        CrudManager<WishlistItem, WishlistItemViewModel, WishlistItemCreateViewModel, WishlistItemUpdateViewModel>,
        IWishlistItemService
    {
        private readonly IProductService _productService;

        public WishlistItemManager(IRepository<WishlistItem> repository, IMapper mapper, IProductService productService)
            : base(repository, mapper)
        {
            _productService = productService;
        }

        public async Task<ProductViewModel> GetProductAsync(int id)
        {
            var model = await _productService.GetByIdAsync(id);

            if (model == null)
                return null!;

            return model;

        }

        public async Task<WishlistItem> CheckProduct(string userId, int id)
        {
            var item = await Repository.GetAsync(predicate: x=>x.AppUserId == userId && x.ProductId==id);

            if (item == null)
                return null!;

            return item; 
        }

    }
}
