using ECommerceProject.DA.DataContext.Entities;
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
        public string? DiscountCode {  get; set; }
        public string? AppUserId {  get; set; }
        public List<OrderDetailViewModel> OrderDetails { get; set; } = [];
        public bool GiftWrap { get; set; }
        public string? Nore {  get; set; }
        public string Email { get; set; } = null!;
        public OrderStatus OrderStatus { get; set; } 
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int AddressId { get; set; }

    }


    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public OrderViewModel Order { get; set; } = null!;
        public int ProductVariantId { get; set; }
        public ProductVariantViewModel ProductVariant {get; set;}=null!;

    }

    public class OrderDetailCreateViewModel
    {
        public int Quantity { get; set; }
        public int ProductVariantId { get; set; }
        public int OrderId { get; set; }
    }
    public class OrderCreateViewModel
    {
        public string? DiscountCode { get; set; }
        public string? AppUserId { get; set; }
        public List<OrderDetailCreateViewModel> OrderDetails { get; set; } = [];
        public bool GiftWrap { get; set; }
        public string? Note { get; set; }
        public string Email { get; set; } = null!;
        public OrderStatus OrderStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int AddressId { get; set; }

    }

    public class OrderDetailUpdateViewModel
    {

    }
    public class OrderUpdateViewModel
    {

    }
}
