using System.Text.Json.Serialization;

namespace BoomTownApp.Models;

public class EventsRepoDTO
{
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    [JsonPropertyName("id")]
    public string Id { get; set; }
}
