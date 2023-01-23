namespace _SharedSignalR.PokerData;

using System.ComponentModel.DataAnnotations;

public class PokerDTO
{
    public string UserName { get; set; } = "Anonymous";
    public string Msg { get; set; } = "";
    [Required]
    public string Room { get; set; } = "";
}
