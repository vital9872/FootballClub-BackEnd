using FCManagement_BackEnd.Dto.User;
using FCManagement_BackEnd.Models;
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
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUserDto model)
        {
            UserDto userDto = new UserDto();
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                var user = _userManager.Users.Where(u => u.UserName == model.UserName).FirstOrDefault();

                userDto.UserName = user.UserName;
                userDto.Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault();

                if (result.Succeeded)
                {
                    return Ok(userDto);
                }
                else
                {
                    return Unauthorized();
                }
            }
            return Ok();
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
