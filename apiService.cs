using System.Net.Http.Headers;
using System.Text.Json;
using BoomTownApp.Models;

namespace BoomTownApp;

public class ApiService
{
    private readonly HttpClient client = new();
    private const string baseUrl = "https://api.github.com/orgs/BoomTownROI";
    public ApiService()
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent", "seth-reeise");
    }
    
    public async Task<OrganizationDTO> GetTopLevelBoomTownOrg()
    {
        var response = await client.GetAsync(baseUrl);

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStreamAsync();
            var repository = await JsonSerializer.DeserializeAsync<OrganizationDTO>(responseBody);
            return repository;    
        }
        
        Console.WriteLine("Error calling top level api, reason: " + response.StatusCode);
        
        return null;
    }

    public async Task<List<ReposDTO>> GetReposData()
    {
        var response = await client.GetAsync(baseUrl + "/repos");
        
        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStreamAsync();
            var repositories = await JsonSerializer.DeserializeAsync<List<ReposDTO>>(responseBody);
            return repositories;
        }
        
        Console.WriteLine("Error calling repos api, reason: " + response.StatusCode);
        
        return null;
    }
    
    public async Task<List<EventsDTO>> GetEventsData()
    {
        var response = await client.GetAsync(baseUrl + "/events");
        
        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStreamAsync();
            var events = await JsonSerializer.DeserializeAsync<List<EventsDTO>>(responseBody);
            
            // get link header to retrieve all events
            var linkHeader = response.Headers.GetValues("link").First();
            var links = linkHeader.Split(',');
            
            // get num of pages
            var lastPage = links[1].Split("page=")[1].Split('>')[0];
            var numOfPages = Int32.Parse(lastPage);

            var nextLink = links[0].Split("<")[1].Split('>')[0];
            
            // loop through to get events for all pages
            for (var i = 1; i < numOfPages; i++)
            {
                response = await client.GetAsync(nextLink);
                if (response.IsSuccessStatusCode)
                {
                    responseBody = await response.Content.ReadAsStreamAsync();
                    var nextEvents = await JsonSerializer.DeserializeAsync<List<EventsDTO>>(responseBody);
                    if (nextEvents == null) continue;
                    events = events?.Concat(nextEvents).ToList();

                    // get next link
                    linkHeader = response.Headers.GetValues("link").First();
                    links = linkHeader.Split(',');
                    nextLink = links[1].Split("<")[1].Split('>')[0];
                }
                else
                {
                    Console.WriteLine("Error getting next events, reason: " + response.StatusCode);
                }
                
            }
            return events;
        }
        
        Console.WriteLine("Error calling events api, reason: " + response.StatusCode);
        return null;
    }
    
    public async Task<List<HooksDTO>> GetHooksData()
    {
        var response = await client.GetAsync(baseUrl + "/hooks");

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStreamAsync();
            var hooks = await JsonSerializer.DeserializeAsync<List<HooksDTO>>(responseBody);
            return hooks;
        }

        Console.WriteLine("Error calling hooks api, reason: " + response.StatusCode);
        return null;
    }
    
    public async Task<List<IssuesDTO>> GetIssuesData()
    {
        var response = await client.GetAsync(baseUrl + "/issues");

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStreamAsync();
            var issues = await JsonSerializer.DeserializeAsync<List<IssuesDTO>>(responseBody);
            return issues;
        }

        Console.WriteLine("Error calling issues api, reason: " + response.StatusCode);
        return null;
    }
    
    public async Task<List<MembersDTO>> GetMembersData()
    {
        var response = await client.GetAsync(baseUrl + "/members");

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStreamAsync();
            var members = await JsonSerializer.DeserializeAsync<List<MembersDTO>>(responseBody);
            return members;
        }
        
        Console.WriteLine("Error calling members api, reason: " + response.StatusCode);
        return null;
    }
    
    public async Task<List<MembersDTO>> GetPublicMembersData()
    {
        var response = await client.GetAsync(baseUrl + "/members");

        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStreamAsync();
            var members = await JsonSerializer.DeserializeAsync<List<MembersDTO>>(responseBody);
            return members;
        }

        Console.WriteLine("Error calling public members api, reason: " + response.StatusCode);
        return null;
    }
}
