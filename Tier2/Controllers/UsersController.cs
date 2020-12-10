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
        public async Task<ActionResult<IList<User>>> GetAllUsersAsync([FromQuery] string username)
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
        
        [HttpGet]
        [Route("Login")]
        public async Task<ActionResult<IList<User>>> GetAllUsersAsync([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                Console.WriteLine(username + " and  " + password);
                User user = await userService.GetSpecificUserLoginAsync(username, password);
                return Ok(user);
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
        
        
        [HttpPatch]
        [Route("{username}")]
        public async Task<ActionResult<User>> UpdateUser([FromBody] User user)
        {
            try
            {
                await userService.UpdateUserAsync(user);
                return Ok(user);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
                
        [HttpDelete("{username}")]
        public async Task<ActionResult> DeleteUser([FromRoute]string username)
        {
            try
            {
                await userService.DeleteUser(username);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
    }
}