using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.DA.DataContext.Repositories
{
    public class DiscountCodeRepository : EFCoreRepository<DiscountCode>, IDiscountCodeRepository
    {
        public DiscountCodeRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}