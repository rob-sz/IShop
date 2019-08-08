using IShop.Common.Dispatching;
using System;
using System.Threading.Tasks;

namespace IShop.Service.Customer.Handler
{
    public class GetCustomerHandler : IRequestHandler<Guid, Model.Customer>
    {
        // inject a mongo repository

        public Task<Model.Customer> HandleAsync(Guid request)
        {
            // retrieve customer from mongo database
            throw new NotImplementedException();
        }
    }
}
