using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.DA.DataContext.Repositories
{
    public class OrderDetailRepository :EFCoreRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository (AppDbContext dbContext) : base(dbContext) { }
    }
}