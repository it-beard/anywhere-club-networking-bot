using Newtonsoft.Json;

namespace Anywhere.Bot.ApiClient;

public class ApiResponse
{
    [JsonProperty("is_user_exists")]
    public bool IsUserExists { get; set; }
    
    [JsonProperty("membership_level")]
    public string MembershipLevel { get; set; }
}