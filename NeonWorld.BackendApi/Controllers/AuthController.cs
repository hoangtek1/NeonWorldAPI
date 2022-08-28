using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeonWorld.Application.System.Carts;
using NeonWorld.Application.System.Orders;
using NeonWorld.Application.System.Users;
using NeonWorld.Entities;
using NeonWorld.ViewModels.Catalog.Products;
using NeonWorld.ViewModels.System.Carts;
using NeonWorld.ViewModels.System.Jwt;
using NeonWorld.ViewModels.System.Users;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NeonWorld.BackendApi.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Profile/Me")]
        public async Task<IActionResult> GetUserProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserAsync(new Guid(userId));
            if(user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(UserLogin userLogin)
        {
            if (userLogin != null)
            {
                var result = _userService.Login(userLogin);
                var splitAccessTokenAndExpiresTime = result.ResultObject.Split(":");
                return Ok(new JwtVm()
                {
                    Access_token = splitAccessTokenAndExpiresTime[0],
                    Expires_in = splitAccessTokenAndExpiresTime[1]
                });
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterRequest userRegister)
        {
            if (userRegister == null)
            {
                return BadRequest();
            }
            var register = _userService.CreateUser(userRegister);
            return Ok(register);
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            var result = _userService.Logout();
            return Ok(result);
        }

        [HttpPost("Profile/Password")]
        public IActionResult Profile(UserChangePassword changePassword)
        {
            if(changePassword == null)
            {
                return BadRequest();
            }
            var result = _userService.ChangePassword(changePassword);
            return Ok(result);
        }
    }
}
