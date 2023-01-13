namespace _SharedSignalR.PokerData;

public class PokerFeatureData
{
    public string Feature { get; set; } = "";
    public string AnswerStyle { get; set; } = "";

    public List<string> Answers { get; set; } = new() { "1", "2", "3", "5", "8", "13" };

    public string RoomName { get; set; } = "";
}
