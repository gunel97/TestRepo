using ECommerceProject.BL.ViewModels;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface IHeaderService
    {
        Task<HeaderViewModel> GetHeaderViewModelAsync();
    }
}
