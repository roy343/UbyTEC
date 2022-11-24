using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace FeedbackAPI.Models;

public class Feed
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("customerID")]
    [JsonPropertyName("customerID")]
    public int customerID { get; set; }

    public string message { get; set; } = null!;

    public int affiliateID { get; set; }
}