using ECommerceProject.BL.ViewModels;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface IShopService
    {
        Task<ShopViewModel> GetShopViewModelAsync();
    }
}
