namespace IShop.Service.Products.Domain.Model
{
    public class Pricing
    {
        public decimal Price { get; private set; }
        public decimal Freight { get; private set; }
        public decimal Tax { get; private set; }

        public decimal GetTotal()
        {
            return Price + Freight + Tax;
        }
    }
}
