using System;
using System.Threading.Tasks;
using IShop.Service.Customers.Domain.Model;

namespace IShop.Service.Customers.Domain
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerAsync(Guid id);
    }
}