using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options) : base(options)
        {

        } 

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                FirstName = "Donald",
                LastName = "Trump",
                Email = "america.fckyeah@gmail.com",
                DateOfBirth = new DateTime(1946, 06, 14),
                PhoneNumber = "999-888-7777"

            }, new Customer
            {
                CustomerId = 2,
                FirstName = "Jan",
                LastName = "Heweliusz",
                Email = "jan.hewe@gmail.com",
                DateOfBirth = new DateTime(1611, 01, 28),
                PhoneNumber = "111-222-3333"
            });
        }
    }
}
