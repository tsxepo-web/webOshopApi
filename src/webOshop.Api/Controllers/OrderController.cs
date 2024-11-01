using Microsoft.AspNetCore.Mvc;
using webOshop.Application.DTO.RequestDTO;
using webOshop.Application.DTO.ResponseDTO;
using webOshop.Domain.Entities;
using webOshop.Domain.Interfaces;

namespace webOshop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(string id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            return order == null ? NotFound() : Ok(order);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByUserId(string userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderRequest orderRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var order = new Order
            {
                UserId = orderRequest.UserId,
                ProductId = orderRequest.ProductId,
                Quantity = orderRequest.Quantity,
                OrderDate = DateTime.UtcNow
            };
            await _orderRepository.AddOrderAsync(order);

            var response = new OrderResponse(
                Id: order.Id!,
                UserId: order.UserId,
                ProductId: order.ProductId,
                Quantity: order.Quantity,
                OrderDate: order.OrderDate
            );
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, response);
        }

        [HttpPatch("{id}/status")]
        public async Task<ActionResult> UpdateOrderStatus(string id, [FromBody] string status)
        {
            await _orderRepository.UpdateOrderStatusAsync(id, status);
            return NoContent();
        }
    }
}
