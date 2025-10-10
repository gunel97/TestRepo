using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.MVC.Areas.Admin.Controllers
{
    public class OrderController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
