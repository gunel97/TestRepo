using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface IBioService : ICrudService<Bio, BioViewModel, BioCreateViewModel, BioUpdateViewModel> { }
}
