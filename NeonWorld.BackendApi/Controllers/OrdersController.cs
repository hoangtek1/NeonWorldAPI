using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeonWorld.Application.System.Orders;
using NeonWorld.Application.System.Users;
using NeonWorld.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NeonWorld.BackendApi.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrdersController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateOrders(Order createOrder)
        {
            if(createOrder != null)
            {
                if (_orderService.CreateOrder(createOrder))
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetUserOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserAsync(new Guid(userId));
            if (user != null)
            {
                var userOrders = _orderService.GetOrder(user.UserID);
                return Ok(userOrders);
            }
            return BadRequest();
        }
    }
}
