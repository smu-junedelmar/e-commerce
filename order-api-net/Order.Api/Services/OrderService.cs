public class OrderService
{
    private readonly OrderRepository _repo;
    private readonly EventBus _eventBus;

    public OrderService(OrderRepository repo, EventBus eventBus)
    {
        _repo = repo;
        _eventBus = eventBus;
    }
    
    public async Task<Order> CreateOrder(Order order)
    {
        await _repo.Create(order);

        _eventBus.Publish(new
        {
            orderId = order.Id,
            userId = order.UserId,
            items = order.Items.Select(i => new { i.ProductId, i.Quantity }),
            createdAt = order.CreatedAt
        });

        return order;
    }

    public Task<List<Order>> GetAllOrders() => _repo.GetAll();
    public Task<Order?> GetOrderById(string id) => _repo.GetById(id);
    public Task<List<Order>> GetOrdersByUserId(string userId) => _repo.GetByUserId(userId);
}
