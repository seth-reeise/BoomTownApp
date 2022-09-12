using System.Text.Json.Serialization;

namespace BoomTownApp.Models;

public class EventsDTO
{
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    [JsonPropertyName("id")]
    public string Id { get; set; }
}
