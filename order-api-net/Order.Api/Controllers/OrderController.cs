using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly OrderService _service;

    public OrderController(OrderService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Order order)
    {
        var result = await _service.CreateOrder(order);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllOrders());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var order = await _service.GetOrderById(id);
        if (order == null) return NotFound();
        return Ok(order);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(string userId) =>
        Ok(await _service.GetOrdersByUserId(userId));
}
