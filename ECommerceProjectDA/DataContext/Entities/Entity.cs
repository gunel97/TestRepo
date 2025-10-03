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

    public class UserWishlistItem : TimeStample
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; } 
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
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
        public List<UserWishlistItem> UserWishlistItems { get; set; } = [];
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
        public int SalePercentage { get; set; }
        public int Quantity { get; set; }
        public List<ProductImage> ProductImages { get; set; } = [];
        public List<OrderDetail> OrderDetails { get; set; } = [];
    }

    public class ProductImage:TimeStample
    {
        public string ImageName { get; set; } = null!;
        public int ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }

    }

    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<UserWishlistItem> UserWishlistItems = [];
        public List<Order> Orders { get; set; } = [];
        public List<Address> Addresses { get; set; } = [];
    }

    public class Order : TimeStample
    {
        public int DiscountCodeId { get; set; }
        public DiscountCode? DiscountCode { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = [];
        public bool GiftWrap { get; set; }
        public string Note { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public class OrderDetail : Entity
    {
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; } = null!;
    }

    public class Address : TimeStample
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Company { get; set; }= null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }

    public class DiscountCode : TimeStample
    {
        public string Code { get; set; } = null!;
        public List<Order> Orders { get; set; } = null!;
        public bool IsActive { get; set; }
    }

}
