namespace FeedbackAPI.Models;

public class DBSettings
{
    public string DatabaseName { get; set; } = null!;

    public string ConnectionString { get; set; } = null!;

    public string CollectionName { get; set; } = null!;
}