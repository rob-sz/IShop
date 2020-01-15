namespace IShop.Service.Products.Domain.Model
{
    public class Shipping
    {
        public decimal Width { get; private set; }
        public decimal Height { get; private set; }
        public decimal Depth { get; private set; }
        public decimal Weight { get; private set; }
    }
}
