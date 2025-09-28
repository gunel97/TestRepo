using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.DA.DataContext.Repositories
{
    public class CurrencyRepository : EFCoreRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}