using FCManagement_BackEnd.Dto.User;
using FCManagement_BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCManagement_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = _userManager.Users.ToList().Select(u => {
                return new UserDto
                {
                    UserName = u.UserName,
                    Role = _userManager.GetRolesAsync(u).Result.FirstOrDefault()
                };
            });
            return Ok(users.ToList());
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetById([FromRoute] string username)
        {
            return Ok(_userManager.Users.Where(u => u.UserName == username).FirstOrDefault());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto model)
        {

            if(model == null)
            {
                return BadRequest();
            }
          
            User user = new User { Email = model.UserName, UserName = model.UserName};
          
            await _userManager.CreateAsync(user, model.Password);
          
            await _userManager.AddToRoleAsync(user, model.Role);
            
            return Ok(user);
        }


        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]EditUserDto model)
        {

           User user = await _userManager.FindByNameAsync(model.PrevUserName);
           if (user != null)
           {
                user.Email = model.UserName;
                user.UserName = model.UserName;

                var roles = await _userManager.GetRolesAsync(user);

                await _userManager.RemoveFromRolesAsync(user, roles);

                await _userManager.AddToRoleAsync(user, model.Role);

                await _userManager.UpdateAsync(user);
           }
           else
           {
                return NoContent();
           }

           return Ok(user);
        }

        [HttpDelete("{username}")]
        public async Task<ActionResult> Delete([FromRoute] string username)
        {
            User user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return Ok(user);
        }
    }
}
