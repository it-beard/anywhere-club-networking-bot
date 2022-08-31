namespace Anywhere.Bot.Data.Entities;

public class UserRepository : IUserRepository
{
    public void AddUser(string apiKey, ulong discordId, string discordName)
    {
        // add user query
        // add log query
        throw new NotImplementedException();
    }

    public void RemoveUser(ulong discordId)
    {
        // remove user query
        // add log query
        throw new NotImplementedException();
    }
}