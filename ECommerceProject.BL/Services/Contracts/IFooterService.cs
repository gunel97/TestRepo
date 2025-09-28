using ECommerceProject.BL.ViewModels;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface IFooterService
    {
        Task<FooterViewModel> GetFooterViewModelAsync();
    }
}
