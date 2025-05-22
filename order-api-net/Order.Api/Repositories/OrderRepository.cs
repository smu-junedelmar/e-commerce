using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class OrderRepository
{
    private readonly IMongoCollection<Order> _orders;

    public OrderRepository(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _orders = database.GetCollection<Order>("Orders");
    }

    public Task<List<Order>> GetAll() => _orders.Find(_ => true).ToListAsync();
    public Task<Order?> GetById(string id) => _orders.Find(o => o.Id == id).FirstOrDefaultAsync();
    public Task<List<Order>> GetByUserId(string userId) => _orders.Find(o => o.UserId == userId).ToListAsync();
    public Task Create(Order order) => _orders.InsertOneAsync(order);
}
