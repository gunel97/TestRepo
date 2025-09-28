using AutoMapper;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.DA.DataContext.Repositories.Contracts;

namespace ECommerceProject.BL.Services
{
    public class BioManager :CrudManager<Bio, BioViewModel, BioCreateViewModel, BioUpdateViewModel>,
        IBioService
    {
        public BioManager(IRepository<Bio> repository, IMapper mapper)
            :base(repository, mapper) 
        {
            
        }
    }
}
