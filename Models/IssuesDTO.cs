using System.Text.Json.Serialization;

namespace BoomTownApp.Models;

public class IssuesDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; }
}