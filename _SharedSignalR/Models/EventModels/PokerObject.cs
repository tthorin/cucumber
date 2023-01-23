namespace _SharedSignalR.Models;

using System.Diagnostics;

public class PokerObject
{
    public string Title { get; set; } = "";
    public string Image { get; set; } = "";
    public List<string> Answers { get; set; } = new();

    public string Room { get; set; } = "";
}