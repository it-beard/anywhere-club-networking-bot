namespace Anywhere.Bot.ApiClient;

public interface IApiClient
{
    ApiResponse GetInfo(string key);
}