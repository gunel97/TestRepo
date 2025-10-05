using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Security.Claims;

namespace ECommerceProject.BL.Services
{
    public class ProductManager : CrudManager<Product, ProductViewModel, ProductCreateViewModel, ProductUpdateViewModel>,
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

        public override async Task<IEnumerable<ProductViewModel>> GetAllAsync(Expression<Func<Product, bool>>? predicate = null, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null, Func<IQueryable<Product>,
            IOrderedQueryable<Product>>? orderBy = null, bool AsNoTracking = false)
        {
            var currentUser = _httpContextAccessor.HttpContext?.User;
            List<WishlistItemViewModel> wishlistItems = [];

            var products = await base.GetAllAsync();

            if (currentUser != null && currentUser.Identity!.IsAuthenticated)
            {
                var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                foreach (var product in products)
                {
                    var item = await _wishlistService.GetAsync(
                        predicate: x => x.AppUserId == userId && x.ProductId == product.Id,
                        include: x => x.Include(p => p.Product));

                    if (item != null)
                        product!.IsInWishlist = true;

                    else
                        product.IsInWishlist = false;
                }
            }
            else
            {
                foreach (var product in products)
                {
                    product.IsInWishlist = false;
                }
            }
            return await base.GetAllAsync(predicate: x => !x.IsDeleted
              , include: x => x
              .Include(pv => pv.ProductVariants).ThenInclude(i => i.ProductImages)
              .Include(pv => pv.ProductVariants).ThenInclude(c => c.Color!));
        }
    }
}
