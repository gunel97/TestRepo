using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.MVC.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IWishlistItemService _wishlistItemService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IProductService _productService;

        public WishlistController(IWishlistItemService wishlistItemService, IProductService productService, UserManager<AppUser> userManager)
        {
            _wishlistItemService = wishlistItemService;
            _productService = productService;
            _userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var items = await GetWishlist();

            return View(items);
        }

        [Authorize]
        public async Task<IActionResult> WishlistHeader()
        {
            var items = await GetWishlist();

            return View(items);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            var productViewModel = await _productService.GetByIdAsync(id);
            if (productViewModel == null)
                return NotFound();

            var username = User.Identity!.Name ?? "";

            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
                return BadRequest();

            var wishlistItems = await GetWishlist();

            var currentItem = wishlistItems.Items.FirstOrDefault(predicate: x=> x.ProductId==id);

            if (currentItem != null)
                return NoContent();


            var createViewModel = new WishlistItemCreateViewModel
            {
                AppUserId = user.Id,
                ProductId = id,
            };

            await _wishlistItemService.CreateAsync(createViewModel);

            return NoContent();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var items = await GetWishlist();
            var product = await _productService.GetByIdAsync(id);
            var currentItem = items.Items.FirstOrDefault(x => x.ProductId == id);
            if (currentItem == null)
                return BadRequest();


            var removed = await _wishlistItemService.DeleteAsync(currentItem.Id);

            if (removed)
            {
                product!.IsInWishlist = false;
                return NoContent();   
            }
            else
                return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetWishlistJ()
        {
            var model = await GetWishlist();

            return Json(model);
        }

        [Authorize]
        private async Task<WishlistItemsViewModel> GetWishlist()
        {
            var username = User.Identity!.Name ?? "";

            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
                return null!;

            var items = await _wishlistItemService.GetAllAsync(predicate: x => x.AppUserId == user.Id && !x.IsDeleted,
                include: x => x
                .Include(p => p.Product).ThenInclude(pv => pv.ProductVariants).ThenInclude(c => c.Color!)
                .Include(p => p.Product).ThenInclude(pv => pv.ProductVariants).ThenInclude(i => i.ProductImages));

            foreach(var item in items)
            {
                item.Product!.IsInWishlist = true;
            }

            var itemsT = new WishlistItemsViewModel();
            itemsT.Items = items.ToList();
            itemsT.Count=items.ToList().Count;

            return itemsT ;
        }
    }
}
