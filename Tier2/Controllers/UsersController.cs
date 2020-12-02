using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEP3_Tier1.Data;
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
        public async Task<ActionResult<Customer>> AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await userService.AddUserAsyncTask(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }


        }
        
        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await userService.AddCustomerAsyncTask(customer);
                return Ok(customer);
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