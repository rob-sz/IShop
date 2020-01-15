﻿using IShop.Common.Messaging.Query;
using IShop.Service.Products.Messages.Query;
using System;
using System.Threading.Tasks;

namespace IShop.Service.Products.Handlers.Query
{
    public class GetCategoriesHandler 
        : IQueryHandler<GetProductCategoriesQuery, GetProductCategoriesResult>
    {
        public async Task<GetProductCategoriesResult> HandleAsync(GetProductCategoriesQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
