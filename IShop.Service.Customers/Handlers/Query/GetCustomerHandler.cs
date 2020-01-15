using IShop.Common.Messaging.Query;
using IShop.Service.Customers.Domain;
using IShop.Service.Customers.Domain.Model;
using IShop.Service.Customers.Messages.Query;
using System.Threading.Tasks;

namespace IShop.Service.Customers.Handler.Query
{
    public class GetCustomerHandler 
        : IQueryHandler<GetCustomerQuery, GetCustomerResult>
    {
        private readonly ICustomerService customerService;

        public GetCustomerHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public async Task<GetCustomerResult> HandleAsync(GetCustomerQuery query)
        {
            var customer = await customerService.GetCustomerAsync(query.Id);

            return new GetCustomerResult(); // todo! map customer to result
            /*return new Customer
            {
                Id = customer.Id,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };*/
        }
    }
}
