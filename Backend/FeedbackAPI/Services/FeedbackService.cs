using FeedbackAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FeedbackAPI.Services;

public class FeedbackService
{
    private readonly IMongoCollection<Feed> _feedbackCollection;

    public FeedbackService(
        IOptions<DBSettings> feedbackDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            feedbackDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            feedbackDatabaseSettings.Value.DatabaseName);

        _feedbackCollection = mongoDatabase.GetCollection<Feed>(
            feedbackDatabaseSettings.Value.CollectionName);
    }

    public async Task<List<Feed>> GetAsync() =>
        await _feedbackCollection.Find(_ => true).ToListAsync();

    public async Task<Feed?> GetAsync(string id) =>
        await _feedbackCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Feed newEntry) =>
        await _feedbackCollection.InsertOneAsync(newEntry);

    public async Task UpdateAsync(string id, Feed updatedFeed) =>
        await _feedbackCollection.ReplaceOneAsync(x => x.Id == id, updatedFeed);

    public async Task RemoveAsync(string id) =>
        await _feedbackCollection.DeleteOneAsync(x => x.Id == id);
}