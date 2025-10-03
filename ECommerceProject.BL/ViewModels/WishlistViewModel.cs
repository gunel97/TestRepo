using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.BL.ViewModels
{
    public class WishlistViewModel
    {
        public int Id { get; set; }
        public string AppUserId { get; set; } = null!;
        public List<ProductViewModel> Products { get; set; } = [];
    }

    public class WishlistCreateViewModel
    {

    }

    public class WishlistUpdateViewModel
    {
    }
}
