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
        private readonly BasketManager _basketManager;
        public OrderDetailManager(IRepository<OrderDetail> repository, IMapper mapper, BasketManager basketManager) : base(repository, mapper)
        {
            _basketManager = basketManager;
        }

        public async Task<List<OrderDetailCreateViewModel>> GetOrderDetailCreateViewModels()
        {
            var basketViewModel = await _basketManager.GetBasketAsync();

            var orderDetailCreateViewModels = new List<OrderDetailCreateViewModel>();

            foreach (var item in basketViewModel.Items)
            {
                orderDetailCreateViewModels.Add(new OrderDetailCreateViewModel()
                {
                    Quantity = item.Quantity,
                    ProductVariantId = item.ProductVariantId,
                });
            }

            return orderDetailCreateViewModels;
        }
    }
}
