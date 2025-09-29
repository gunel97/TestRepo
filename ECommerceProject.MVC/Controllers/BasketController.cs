using ECommerceProject.BL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceProject.MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly BasketManager _basketManager;

        public BasketController(BasketManager basketManager)
        {
            _basketManager = basketManager;
        }

        [HttpPost]
        public IActionResult Add(int productVariantId, int quantity)
        {
            _basketManager.AddToBasket(productVariantId, quantity);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            _basketManager.RemoveFromBasket(id);

            return NoContent();
        }

        public async Task<IActionResult> GetBasket()
        {
            var model = await _basketManager.GetBasketAsync();

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeQuantity(int productVariantId, int change)
        {
            var basketViewModel = await _basketManager.ChangeQuantityAsync(productVariantId, change);

            return Json(new
            {
                success = true,
                basketViewModel
            });
        }
    }
}
