using System;

namespace BasicUsage
{
    public interface ICustomerRepository
    {
        Customer Find(Guid id);
    }

    public class SimpleCustomerRepository : ICustomerRepository
    {
        public Customer Find(Guid id)
        {
            return new Customer()
            {
                CustomerId = id,
                Name = "James Bond",
                Email = "james@bond.com",
            };
        }
    }

    public class Customer
    {
        public Guid CustomerId { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
    }
}
