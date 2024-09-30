using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderServiceApp.IServices;
using OrderServiceApp.Models;
using OrderServiceApp.Models.DTO;

namespace OrderServiceApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        return Ok(await _orderService.GetAllOrdersAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> PostOrder(OrderDTO orderDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var order = new Order
        {
            CustomerName = orderDTO.CustomerName,
            TotalAmount = orderDTO.TotalAmount
        };

        await _orderService.AddOrderAsync(order);

        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrder(int id, OrderDTO orderDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != orderDTO.Id)
        {
            return BadRequest();
        }

        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }

        order.CustomerName = orderDTO.CustomerName;
        order.TotalAmount = orderDTO.TotalAmount;

        try
        {
            await _orderService.UpdateOrderAsync(order);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _orderService.OrderExistsAsync(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }

        await _orderService.DeleteOrderAsync(id);

        return NoContent();
    }
}
