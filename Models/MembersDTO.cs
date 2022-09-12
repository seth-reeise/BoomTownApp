using System.Text.Json.Serialization;

namespace BoomTownApp.Models;

public class MembersDTO
{
    [JsonPropertyName("login")]
    public string Login { get; set; }
    
    [JsonPropertyName("id")]
    public int Id { get; set; }
}
