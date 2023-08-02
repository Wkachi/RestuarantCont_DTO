using CCSARestaurant.Core;
using CCSARestaurant.DB;
using CCSARestaurant.DB.Repositories;
using CCSARestaurantAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CCSARestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //Read
        [HttpGet(Name = "GetCustomer")]
        public IEnumerable<Customer> Get()
        {
            var customers = _customerRepository.GetAll();
            return customers;
        }

        //Create
        [HttpPost("/create-customer-using-params")]
        public IActionResult CreateCustomer(string firstName, string surname, string phoneNumber)
        {
            var customer = new Customer
            {
                FirstName = firstName,
                Surname = surname,
                PhoneNumber = phoneNumber
            };

            _customerRepository.Add(customer);
            return Ok(customer.Id);
        }

        //Create
        [HttpPost("/create-customer")]
        public IActionResult CreateCustomer([FromBody] CustomerDTO customer)
        {
            var myCustomer = new Customer
            {
                FirstName = customer.FirstName,
                Surname = customer.Surname,
                PhoneNumber = customer.PhoneNumber
            };

            _customerRepository.Add(myCustomer);
            return Ok(myCustomer.Id);
        }

        //Update
        [HttpPut("/update-first-name")]
        public IActionResult UpdateCustomerDetails(int id, string firstName)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return BadRequest();
            }

            customer.FirstName = firstName;

            _customerRepository.Update(customer);
            return Ok(customer.Id);
        }

        //Delete
        [HttpDelete("/delete-user")]
        public IActionResult DeleteUserById(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return BadRequest();
            }

            _customerRepository.DeleteById(id);
            return Ok(customer.Id);
        }

        private readonly CustomerRepository _customerRepository;
    }
}
