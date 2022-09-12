using System.Text.Json.Serialization;

namespace BoomTownApp.Models;

public class OrganizationDTO
{
    [JsonPropertyName("login")]
    public string Login { get; set; }
    
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("url")]
    public string Url { get; set; }
    
    [JsonPropertyName("repos_url")]
    public string ReposUrl { get; set; }
    
    [JsonPropertyName("events_url")]
    public string EventsUrl { get; set; }
    
    [JsonPropertyName("hooks_url")]
    public string HooksUrl { get; set; }
    
    [JsonPropertyName("issues_url")]
    public string IssuesUrl { get; set; }
    
    [JsonPropertyName("members_url")]
    public string MembersUrl { get; set; }
    
    [JsonPropertyName("public_members_url")]
    public string PublicMembersUrl { get; set; }
    
    [JsonPropertyName("public_repos")]
    public int PublicRepos { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
    
    [JsonPropertyName("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; }
}
