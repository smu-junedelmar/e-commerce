using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Item
{
    public string ProductId { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public int Quantity { get; set; }
}

public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string UserId { get; set; }
    public List<Item> Items { get; set; }
    public string Status { get; set; } = "pending";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
