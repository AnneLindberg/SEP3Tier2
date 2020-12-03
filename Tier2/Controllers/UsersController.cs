using System;
using System.Collections.Generic;
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

        [HttpGet]
        public async Task<ActionResult<IList<User>>> GetAllUsersAsync()
        {
            try
            {
                IList<User> users = await userService.GetAllUsersAsync();

                foreach (User user in users)
                {
                    Console.WriteLine("?!?!?!??!?!" + user.username);
                }

                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
                // TODO Add more exceptions? 404?
            }
        }

        /*
        [HttpGet]
        [Route("[action]{username}/{password}")]
        public async Task<ActionResult<User>> GetSpecificUserAsync([FromQuery] string username, string password)
        {
            Console.WriteLine("THE WALLS ARE GETTING CLOSER");
            try
            {
                User user = await userService.GetSpecificUserAsync(username, password);
                Console.WriteLine(" ControllerUSer \n" + "Username: " + user.username + "\n" + "Password: " + user.password + "\n" + "Role: " + user.role);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
                // TODO Add more exceptions? 404?
            }
        }*/

        
        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetSpecificUserAsync([FromQuery] string username)
        {
            Console.WriteLine("THE WALLS ARE GETTING CLOSER");
            try
            {
                User user = await userService.GetSpecificUserAsync(username);
                Console.WriteLine(" ControllerUSer \n" + "Username: " + user.username + "\n" + "Password: " +
                                  user.password + "\n" + "Role: " + user.role);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
                // TODO Add more exceptions? 404?
            }
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
                await userService.CreateUserAsync(user);
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
    }
}