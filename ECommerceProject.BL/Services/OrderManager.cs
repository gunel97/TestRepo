using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.BL.Services
{
    public class OrderManager:CrudManager<Order, OrderViewModel, OrderCreateViewModel, OrderUpdateViewModel>,
        IOrderService
    {
        public OrderManager(IRepository<Order> repository, IMapper mapper):base(repository, mapper) { }
    }
}
