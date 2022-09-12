using System.Text.Json.Serialization;

namespace BoomTownApp.Models;

public class HooksDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
}