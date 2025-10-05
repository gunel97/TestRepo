using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface IOrderService:ICrudService<Order, OrderViewModel, OrderCreateViewModel, OrderUpdateViewModel> { }
}
