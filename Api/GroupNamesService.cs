namespace Api;

public class GroupNamesService : IGroupNamesService
{
    public HashSet<string> GroupNames { get; set; } = new();
}