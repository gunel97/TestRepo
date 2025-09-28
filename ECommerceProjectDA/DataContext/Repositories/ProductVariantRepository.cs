using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.DA.DataContext.Repositories
{
    public class ProductVariantRepository :EFCoreRepository<ProductVariant>, IProductVariantRepository
    {
        public ProductVariantRepository(AppDbContext dbContext):base(dbContext) { }
    }
}