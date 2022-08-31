namespace Anywhere.Bot.Data;

public interface IUserRepository
{
    void AddUser(string apiKey, ulong discordId, string discordName);

    void RemoveUser(ulong discordId);
}