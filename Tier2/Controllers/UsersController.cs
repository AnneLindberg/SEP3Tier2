using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEP3_Tier1.Data;
using Tier2.Models.Users;

namespace Tier2.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _user;

        public UsersController(IUserService user)
        {
            _user = user;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
                await _user.CreateUserAsyncTask(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }


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
                
                Customer customerToAdd = await _user.CreateCustomerAsync(customer);
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