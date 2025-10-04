using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface IWishlistItemService
        : ICrudService<WishlistItem, WishlistItemViewModel, WishlistItemCreateViewModel, WishlistItemUpdateViewModel>
    {
        Task<ProductViewModel> GetProductAsync(int id);

        Task<WishlistItem> CheckProduct(string userId, int id);
    }
}
