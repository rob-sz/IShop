using IShop.Common.Domain.Model;
using System;

namespace IShop.Service.Customers.Domain.Model
{
    public class Customer : IAggregateRoot
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
