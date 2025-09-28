using ECommerceProject.DA.DataContext.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.BL.ViewModels
{
    public class ProductVariantViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int ColorId { get; set; }
        public string? ColorName { get; set; }
        public string? ColorIconName { get; set; }
        public string? CoverImageName { get; set; }
        public IList<string> ImageNames { get; set; } = [];
    }
    public class ProductVariantCreateViewModel { }
    public class ProductVariantUpdateViewModel { }
}
