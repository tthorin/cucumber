namespace _SharedSignalR.PokerData;

using System.ComponentModel.DataAnnotations;

public class PokerClientSettings
{
    public string Username { get; set; } = "Anonymous";
    public string Msg { get; set; } = "";
    [Required]
    public string Room { get; set; } = "";
}
