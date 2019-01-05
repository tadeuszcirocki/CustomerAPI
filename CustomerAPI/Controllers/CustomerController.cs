using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAPI.Models;
using CustomerAPI.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IDataRepository<Customer> _dataRepository;

        public CustomerController(IDataRepository<Customer> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        //GET: api/Customer
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Customer> customers = _dataRepository.GetAll();
            return Ok(customers);
        }
         //GET: api/Customer/5
         [HttpGet("{id}", Name = "Get")]
         public IActionResult Get(long id)
        {
            Customer customer = _dataRepository.Get(id);

            if (customer == null)
            {
                return NotFound("The customer could not be found.");
            }

            return Ok(customer);
        }

        //POST: api/Customer
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer is null.");
            }

            _dataRepository.Add(customer);
            return CreatedAtRoute("Get", new { Id = customer.CustomerId }, customer);
        }

        //PUT: api/Customer/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer is null.");
            }

            Customer customerToUpdate = _dataRepository.Get(id);
            if (customerToUpdate == null)
            {
                return NotFound("The customer could not be found.");
            }

            _dataRepository.Update(customerToUpdate, customer);
            return NoContent();
        }

        //DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Customer customer = _dataRepository.Get(id);
            if (customer == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _dataRepository.Delete(customer);
            return NoContent();
        }
    }
}