using System;
using System.Collections.Generic;

namespace IShop.Service.Products.Persistence.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Pricing Pricing { get; set; }
        public Category Category { get; set; }
        public Dimensions Dimensions { get; set; }
        public Shipping Shipping { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
    }
}
