namespace IShop.Service.Products.Persistence.Model
{
    public class Pricing
    {
        public decimal Price { get; private set; }
        public decimal Freight { get; private set; }
        public decimal Tax { get; private set; }
    }
}
