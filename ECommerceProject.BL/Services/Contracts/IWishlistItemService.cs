using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface IWishlistItemService
        : ICrudService<WishlistItem, WishlistItemViewModel, WishlistItemCreateViewModel, WishlistItemUpdateViewModel>
    {
        Task<WishlistItemViewModel> CheckProduct(string userId, int id);
    }
}
