using System;

namespace IShop.Service.Customers.Messages.Query
{
    public class GetCustomerResult
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
