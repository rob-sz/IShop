using IShop.Common.Mongo;
using IShop.Service.Customers.Domain.Model;
using System;
using System.Threading.Tasks;

namespace IShop.Service.Customers.Domain
{
    public class CustomerService : ICustomerService
    {
        private IMongoDbRepository<Customer> customerRepository;

        public CustomerService(IMongoDbRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> GetCustomerAsync(Guid id)
            => await customerRepository.GetAsync(customer => customer.Id == id);
    }
}
