using IShop.Service.Products.Messages.Command;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;

namespace IShop.Service.Products.Swagger
{
    // provide example to generate new product id guid

    public class CreateProductCommandExample : IExamplesProvider<CreateProductCommand>
    {
        public CreateProductCommand GetExamples()
        {
            return new CreateProductCommand
            {
                Product = new Domain.Model.Product
                {
                    Attributes = new Dictionary<string, string>
                    {
                        { "additionalProp1", "string" },
                        { "additionalProp2", "string" },
                        { "additionalProp3", "string" }
                    },
                    Category = new Domain.Model.Category
                    {
                        Description = "string",
                        Name = "string"
                    },
                    Description = "string",
                    Dimensions = new Domain.Model.Dimensions(),
                    Id = Guid.NewGuid(),
                    ImageUrl = "string",
                    Name = "string",
                    Pricing = new Domain.Model.Pricing(),
                    Shipping = new Domain.Model.Shipping()
                }
            };
        }
    }
}
