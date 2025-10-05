using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.BL.Services
{
    public class OrderDetailManager : CrudManager<OrderDetail, OrderDetailViewModel, OrderDetailCreateViewModel, OrderDetailUpdateViewModel>,
        IOrderDetailService
    {
        public OrderDetailManager(IRepository<OrderDetail> repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
