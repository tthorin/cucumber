namespace _SharedSignalR.Models;

public class PokerObject
{
    public string Title { get; set; } = "";
    public string Image { get; set; } = "";
    public List<string> Answers { get; set; } = new();
}