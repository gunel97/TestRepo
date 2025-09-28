using ECommerceProject.BL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.MVC.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly IHeaderService _headerService;

        public HeaderViewComponent(IHeaderService headerService)
        {
            _headerService = headerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _headerService.GetHeaderViewModelAsync();

            return View(model);
        }
    }
}
