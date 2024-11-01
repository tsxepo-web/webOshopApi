using MediatR;
using Microsoft.AspNetCore.Mvc;
using webOshop.Application.Commands;
using webOshop.Application.DTO.RequestDTO;
using webOshop.Application.DTO.ResponseDTO;
using webOshop.Application.Queries;
using webOshop.Domain.Entities;
using webOshop.Domain.Interfaces;

namespace webOshop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(string id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id));
            return order == null ? NotFound() : Ok(order);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByUserId(string userId)
        {
            var orders = await _mediator.Send(new GetOrdersByUserIdQuery(userId));
            if (orders == null || !orders.Any()) return NotFound("No order found for the specified user.");
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            if (request == null) return BadRequest("Order request can not be null,");
            var result = await _mediator.Send(new CreateOrderCommand(request));
            if (result == null) return BadRequest("Order creation failed");

            return CreatedAtAction(nameof(GetOrderById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrderStatus(string id, [FromBody] CreateOrderRequest request)
        {
            var command = new UpdateOrderCommand(id, request.Status);
            var result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            var command = new DeleteOrderCommand(id);
            var response = await _mediator.Send(command);
            return response ? NoContent() : NotFound();
        }
    }
}
