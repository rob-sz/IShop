using IShop.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IShop.Service.Products.Domain.Model
{
    public class Product : IAggregateRoot
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
        public Pricing Pricing { get; set; }
        public Dimensions Dimensions { get; set; }
        public Shipping Shipping { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
    }
}
