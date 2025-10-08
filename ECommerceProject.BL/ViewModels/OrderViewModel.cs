using ECommerceProject.DA.DataContext.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.BL.ViewModels
{
    
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string? Discount {  get; set; }
        public string? AppUserId {  get; set; }
        public List<OrderDetailViewModel> OrderDetails { get; set; } = [];
        public bool GiftWrap { get; set; }
        public string? Note {  get; set; }
        public string Email { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; } 
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int AddressId { get; set; }
        public AddressViewModel? AddressViewModel { get; set; }

    }


    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductVariantId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductVariantColorName { get; set; } = null!;
        public string ProductVariantImageName { get; set; }=null!;
        public decimal TotalPrice {  get; set; }

    }

    public class OrderDetailCreateViewModel
    {
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductVariantId { get; set; }
        public ProductVariantViewModel ProductVariantViewModel { get; set; } = null!;
        //public string ProductName { get; set; } = null!;
        //public string ProductVariantColorName { get; set; } = null!;
        //public string ProductVariantImageName { get; set; } = null!;
        //public decimal TotalPrice { get; set; }
    }
    public class OrderCreateViewModel
    {
        public bool HasAppliedDiscount {  get; set; }
        public string? Discount { get; set; }
        public int? DiscountCodeId { get; set; }
        public string? AppUserId { get; set; }
        public List<OrderDetailCreateViewModel> OrderDetails { get; set; } = [];
        public bool GiftWrap { get; set; }
        public string? Note { get; set; }
        public string Email { get; set; } = null!;
        public OrderStatus OrderStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public AddressCreateViewModel? AddressCreateViewModel { get; set; } 
        public AddressViewModel? AddressViewModel { get; set; } 
        public bool AcceptTermsConditions {  get; set; }
        public decimal TotalPrice { get; set; }
        public BasketViewModel? BasketViewModel { get; set; }
    }

    public class OrderDetailUpdateViewModel
    {

    }
    public class OrderUpdateViewModel
    {

    }
}
