using IShop.Common.Messaging.Command;
using System;

namespace IShop.Service.Customers.Messages.Command
{
    public class CreateCustomerCommand : ICommand
    {
        // q: should there be a separate identity service? a: probably
        // q: should this be split into create customer and update customer?
        //      a: create would have fields from the create identity command (except password, ie. id and email only)
        //      a: later customer can update the rest of their details, but id and email are minimum requirements to define customer

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
