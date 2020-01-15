﻿using System;
using System.Collections.Generic;

namespace IShop.Gateway.Services.Product.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
    }
}
