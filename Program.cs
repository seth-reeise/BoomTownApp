using BoomTownApp;
using BoomTownApp.Models;

ApiService apiService = new ApiService();

var topLevelRepo = await apiService.GetTopLevelBoomTownRepo();

Console.WriteLine("Output Data:");

await GetRepos();

await GetEvents();

await GetHooks();

await GetIssues();

await GetMembers();

await GetPublicMembers();

await performVerification(topLevelRepo);

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
            Console.WriteLine("Name: " + hook.Name + ", id: " + hook.Name);
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
            Console.WriteLine("Name: " + issue.Name + ", id: " + issue.Name);
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

async Task performVerification(Repository repository)
{
    Console.WriteLine("\n" + "Perform verifications:" + "\n");
    if (repository?.UpdatedAt > repository?.CreatedAt)
    {
        Console.WriteLine("Updated date is later than created date.");
    }
    else
    {
        Console.WriteLine("Error! Updated date is before created date!");
    }
    Console.WriteLine();
    
    var repos = await apiService.GetReposData();
    Console.WriteLine("Top level repo count: " + repository?.PublicRepos);
    Console.WriteLine("Repo count in \"/repos\": " + repos?.Count);
    if (repository?.PublicRepos == repos?.Count)
    {
        Console.WriteLine("Repos count is correct.");
    }
}
