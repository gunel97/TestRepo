using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.DA.DataContext.Entities
{
    public class Entity
    {
        public int Id { get; set; }
    }

    public class TimeStample:Entity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class Language : TimeStample
    {
        public string Name { get; set; } = null!;
        public string IconName { get; set; } = null!;
    }

    public class Currency : TimeStample
    {
        public string CurrencyName { get; set; } = null!;   
        public string Symbol {  get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public string IconName { get; set; } = null!;
    }

    public class Bio:TimeStample
    {
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; }=null!;
        public string LocationUrl { get; set; } = null!;
    }

    public class Social:Entity
    {
        public string Name { get; set; } = null!;
        public string IconName { get; set; } = null!;
        public string Url { get; set; } = null!;
    }

    public class Category:TimeStample
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageName { get; set; } = null!;
        public List<Product> Products { get; set; } = [];
    }

    public class Product:TimeStample
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string AdditionalInformation { get; set; } = null!;
        public decimal? BasePrice { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<ProductVariant> ProductVariants { get; set; } = [];
    }
    public class Color:TimeStample
    {
        public string Name { get; set; } = null!;
        public string IconName { get; set; } = null!;
    }
    public class ProductVariant : TimeStample
    {
        public int ProductId {  get; set; }
        public Product? Product { get; set; }
        public int ColorId { get; set; }
        public Color? Color { get; set; }
        public string CoverImageName { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<ProductImage> ProductImages { get; set; } = [];
    }

    public class ProductImage:TimeStample
    {
        public string ImageName { get; set; } = null!;
        public int ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }

    }

    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? ProfileImageName { get; set; }
    }


}
