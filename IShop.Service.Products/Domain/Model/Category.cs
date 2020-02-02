using System.ComponentModel.DataAnnotations;

namespace IShop.Service.Products.Domain.Model
{
    public class Category
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
