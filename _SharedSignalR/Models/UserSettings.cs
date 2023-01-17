namespace _SharedSignalR.Models;

using System.ComponentModel.DataAnnotations;

public class UserSettings
{
    public string Username { get; set; } = "Anonymous";
    [Required]
    public string Room { get; set; } = "";
}
