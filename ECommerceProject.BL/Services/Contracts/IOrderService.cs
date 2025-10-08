using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface IOrderService 
        : ICrudService<Order, OrderViewModel, OrderCreateViewModel, OrderUpdateViewModel>
    {
        Task<OrderCreateViewModel> GetUserAndAddressViewModel(OrderCreateViewModel model);
        Task<DiscountCodeViewModel> GetDiscount(string discountCode);
    }
}
