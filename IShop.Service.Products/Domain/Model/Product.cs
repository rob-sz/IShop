using IShop.Common.Domain.Model;
using System;
using System.Collections.Generic;

namespace IShop.Service.Products.Domain.Model
{
    public class Product : IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Category Category { get; private set; }
        public Pricing Pricing { get; private set; }
        public Dimensions Dimensions { get; private set; }
        public Shipping Shipping { get; private set; }
        public Dictionary<string, string> Attributes { get; private set; }
    }
}
