using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.MVC.Areas.Admin.Controllers
{
    public class ColorController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
