﻿namespace IShop.Service.Products.Domain.Model
{
    public class Pricing
    {
        public decimal Price { get; set; }
        public decimal Freight { get; set; }
        public decimal Tax { get; set; }

        public decimal GetTotal()
        {
            return Price + Freight + Tax;
        }
    }
}
