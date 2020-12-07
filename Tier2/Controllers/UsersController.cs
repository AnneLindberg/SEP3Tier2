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
        public async Task<ActionResult<IList<User>>> GetUserListAsync([FromQuery] string username)
        {
            try
            {
                IList<User> users = await userService.GetUserListAsync(username);

                

                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
                // TODO Add more exceptions? 404?
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> CreateUserAsync([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                User userToBeAdded = await userService.CreateUserAsync(user);
                return Created($"/{userToBeAdded.username}",userToBeAdded);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
    }
}