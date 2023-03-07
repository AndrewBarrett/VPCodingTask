using BAS.VPTask.Application.Interfaces;
using BAS.VPTask.Core.DTOs.Order;
using Microsoft.AspNetCore.Mvc;

namespace BAS.VPTask.API.Controllers
{
    [ApiController]
    [Route("api/Order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("PlaceGuestOrder")]
        public async Task<IActionResult> PlaceGuestOrder([FromBody] OrderDto orderDto)
        {
            try
            {
                OrderResultDto orderResult = await _orderService.CreateGuestOrderAsync(orderDto);
                return StatusCode(orderResult.Success ? 201 : 500, orderResult);
            }
            catch (Exception ex)
            {
                // Log ex.Message here
                return StatusCode(500);
            }
        }
    }
}