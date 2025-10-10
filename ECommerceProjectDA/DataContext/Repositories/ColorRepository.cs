using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.DA.DataContext.Repositories
{
    public class ColorRepository : EFCoreRepository<Color>, IColorRepository
    {
        public ColorRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}