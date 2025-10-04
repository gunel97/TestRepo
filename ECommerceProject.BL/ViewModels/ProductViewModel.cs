using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.DA.DataContext.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerceProject.BL.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string DetailsUrl => $"{Name?.Replace(" ", "-").Replace("/", "-")}-{Id}";
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? AdditionalInformation { get; set; }
        public decimal BasePrice { get; set; }
        public string? CategoryName { get; set; }
        public List<ProductVariantViewModel> ProductVariants { get; set; } = [];
        public bool IsInWishlist {  get; set; }
        public List<int> WishlistItemIds { get; set; } = [];
                
    }

    public class ProductCreateViewModel
    {
        public string Name { get; set; } = null!;
        public string Description {  get; set; }=null!;
        public string? AdditionalInformation { get; set; }
        public decimal BasePrice { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem> CategorySelectListItems { get; set; } = [];
    }

    public class ProductUpdateViewModel { }

  
}
