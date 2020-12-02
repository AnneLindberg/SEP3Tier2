using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tier2.Data;
using Tier2.Models.Users;

namespace Tier2.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController()
        { 
            userService = new UserService();
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
                
                await userService.CreateUserAsyncTask(user);
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
                
                Customer customerToAdd = await userService.CreateCustomerAsync(customer);
                return Created($"/{customerToAdd.username}", customerToAdd);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
       
        
        [HttpGet]
        public async Task<ActionResult<User>> GetSpecificUserAsync([FromQuery] string username, string password)
        {
            Console.WriteLine("Get user " + username);
            try
            {
                User user = await userService.GetSpecificUserAsync(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
                // TODO Add more exceptions? 404?
            }
        }

    }
}