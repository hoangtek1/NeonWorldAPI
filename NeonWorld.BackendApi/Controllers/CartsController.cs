using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeonWorld.Application.System.Carts;
using NeonWorld.Application.System.Users;
using NeonWorld.ViewModels.System.Carts;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NeonWorld.BackendApi.Controllers
{
    [Route("api/Carts")]
    [ApiController]
    [Authorize]
    public class CartsController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IUserService _userService;
        public CartsController(ICartService cartService, IUserService userService)
        {
            _cartService = cartService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserAsync(new Guid(userId));
            if (user != null)
            {
                var getUserCart = await _cartService.GetUserCartAsync(user.UserID);
                return Ok(getUserCart);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserCart(CartUpdateVm cartUpdateVm)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserAsync(new Guid(userId));
            if (user != null)
            {
                await _cartService
                    .UpdateUserCart(user.UserID, cartUpdateVm.Product_id, cartUpdateVm.Amount);
                return Ok();
            }
            return NotFound();
        }

        [HttpPost("Remove/{id:int}")]
        public async Task<IActionResult> RemoveUserCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserAsync(new Guid(userId));
            if (user != null)
            {
                await _cartService
                    .RemoveUserCart(user.UserID, id);
                return Ok();
            }
            return NotFound();
        }
    }
}
