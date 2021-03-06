﻿using IShop.Common.Mongo;
using IShop.Service.Customers.Domain.Model;
using System;
using System.Threading.Tasks;

namespace IShop.Service.Customers.Domain
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoDbRepository<Customer> customerRepository;

        public CustomerService(IMongoDbRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> GetCustomerAsync(Guid id)
            => await customerRepository.GetAsync(customer => customer.Id == id);

        public async Task CreateCustomerAsync(Customer customer)
            => await customerRepository.CreateAsync(customer);
    }
}
