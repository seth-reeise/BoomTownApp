using BoomTownApp;
using BoomTownApp.Models;

var apiService = new ApiService();

var topLevelOrg = await apiService.GetTopLevelBoomTownOrg();

Console.WriteLine("Output Data:");

await GetRepos();

await GetEvents();

await GetHooks();

await GetIssues();

await GetMembers();

await GetPublicMembers();

await performVerification(topLevelOrg);

async Task GetRepos()
{
    Console.WriteLine("\n" + "Repos:");
    var repositories = await apiService.GetReposData();

    if (repositories != null)
    {
        foreach (var repo in repositories)
        {
            Console.WriteLine("Name: " + repo.Name + ", id: " + repo.Id);
        }
    }
}

async Task GetEvents()
{
    Console.WriteLine("\n" + "Events:");
    var events = await apiService.GetEventsData();

    if (events != null)
    {
        foreach (var e in events)
        {
            Console.WriteLine("Type: " + e.Type + ", id: " + e.Id);
        }
    }
}

async Task GetHooks()
{
    Console.WriteLine("\n" + "Hooks:");
    var hooks = await apiService.GetHooksData();

    if (hooks != null)
    {
        foreach (var hook in hooks)
        {
            Console.WriteLine("Name: " + hook.Name + ", id: " + hook.Id);
        }
    }
}

async Task GetIssues()
{
    Console.WriteLine("\n" + "Issues:");
    var issues = await apiService.GetIssuesData();

    if (issues != null)
    {
        foreach (var issue in issues)
        {
            Console.WriteLine("Name: " + issue.Title + ", id: " + issue.Id);
        }
    }
}

async Task GetMembers()
{
    Console.WriteLine("\n" + "Members:");
    var members = await apiService.GetMembersData();

    if (members != null)
    {
        foreach (var member in members)
        {
            Console.WriteLine("Name: " + member.Login + ", id: " + member.Id);
        }
    }
}

async Task GetPublicMembers()
{
    Console.WriteLine("\n" + "Public members:");
    var publicMembers = await apiService.GetPublicMembersData();

    if (publicMembers != null)
    {
        foreach (var member in publicMembers)
        {
            Console.WriteLine("Name: " + member.Login + ", id: " + member.Id);
        }
    }
}

async Task performVerification(OrganizationDTO organization)
{
    Console.WriteLine("\n" + "Perform verifications:" + "\n");
    if (organization?.UpdatedAt > organization?.CreatedAt)
    {
        Console.WriteLine("Updated date is later than created date.");
    }
    else
    {
        Console.WriteLine("Error! Updated date is before created date!");
    }

    var repos = await apiService.GetReposData();
    Console.WriteLine("\n" + "Top level repo count: " + organization?.PublicRepos);
    Console.WriteLine("Repo count in \"/repos\": " + repos?.Count);
    if (organization?.PublicRepos == repos?.Count)
    {
        Console.WriteLine("Repos count is correct.");
    }
}
