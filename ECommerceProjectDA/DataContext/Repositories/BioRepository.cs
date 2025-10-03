using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.DA.DataContext.Repositories
{
    public class BioRepository : EFCoreRepository<Bio>, IBioRepository
    {
        public BioRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }

}