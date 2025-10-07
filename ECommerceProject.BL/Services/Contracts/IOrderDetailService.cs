using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface IOrderDetailService
        : ICrudService<OrderDetail, OrderDetailViewModel, OrderDetailCreateViewModel, OrderDetailUpdateViewModel>
    {
        Task<List<OrderDetailCreateViewModel>> GetOrderDetailCreateViewModels();
    }
}
