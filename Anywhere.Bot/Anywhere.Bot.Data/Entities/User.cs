namespace Anywhere.Bot.Data.Entities;

public class User
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public ulong DiscordId { get; set; }
    
    public string DiscordName { get; set; }
    
    public String ApiKey { get; set; }
}