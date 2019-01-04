using CustomerAPI.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Models.DataManager
{
    public class CustomerManager : IDataRepository<Customer> //handles all database operations related to the customer (separates data operation logic from Controller)
    {
        readonly CustomerContext _customerContext;

        public CustomerManager(CustomerContext context) //DI via constructor
        {
            _customerContext = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerContext.Customers.ToList();
        }

        public Customer Get(long id)
        {
            return _customerContext.Customers.FirstOrDefault(e => e.CustomerId == id);
        }

        public void Add(Customer entity)
        {
            _customerContext.Customers.Add(entity);
            _customerContext.SaveChanges();
        }

        public void Update(Customer customer, Customer entity)
        {
            customer.FirstName = entity.FirstName;
            customer.LastName = entity.LastName;
            customer.Email = entity.Email;
            customer.DateOfBirth = entity.DateOfBirth;
            customer.PhoneNumber = entity.PhoneNumber;

            _customerContext.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _customerContext.Customers.Remove(customer);
            _customerContext.SaveChanges();
        }
    }
}
