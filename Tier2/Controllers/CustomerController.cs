using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tier2.Data;
using Tier2.Models.Users;

namespace Tier2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController()
        {
            customerService = new CustomerService();
        }


        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Customer customerToAdd = await customerService.CreateCustomerAsync(customer);
                return Created($"/{customerToAdd.username}", customerToAdd);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}