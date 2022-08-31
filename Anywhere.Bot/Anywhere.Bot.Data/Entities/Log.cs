namespace Anywhere.Bot.Data.Entities;

public class Log
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public Guid UserId { get; set; }
    
    public string ApiKey { get; set; }
    
    public ulong DiscordId { get; set; }
    
    public string DiscordName { get; set; }
    
    public ActionType ActionType { get; set; }
}