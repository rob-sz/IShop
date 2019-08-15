using IShop.Common.Dispatching;
using IShop.Service.Customers.Domain;
using IShop.Service.Customers.Domain.Model;
using System;
using System.Threading.Tasks;

namespace IShop.Service.Customers.Handler.Query
{
    public class GetCustomerHandler : IQueryHandler<Guid, Customer>
    {
        private readonly ICustomerService customerService;

        public GetCustomerHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public async Task<Customer> HandleAsync(Guid id)
            => await customerService.GetCustomerAsync(id);
    }
}
