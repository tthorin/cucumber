namespace MauiBlazor.Factories;

using _SharedSignalR.Models;

internal static class PokerObjectFactory
{
	internal static PokerObject GetTshirtStyle(string roomName)
	{
		return new()
		{
			Room = roomName,
			Title = "T-shirt",
			Answers = new()
				{
					"XXL",
					"XL",
					"X",
					"L",
					"M",
					"S",
					"coffee",
					"infinity"
				},
			Image = "/Images/shirt.svg"
		};
	}
	internal static PokerObject GetUserStoriesStyle(string roomName)
	{
		return new()
		{
			Room = roomName,
			Title = "User stories",
			Answers = new()
			{
				"0",
				"1",
				"2",
				"3",
				"5",
				"8",
				"13",
				"21",
				"50",
				"100",
				"url,question-mark",
				"coffee",
				"infinity"
			},
			Image = "/Images/comments.svg"
		};
	}
	internal static PokerObject GetDelegationPokerStyle(string roomName)
	{
		return new()
		{
			Room = roomName,
			Title = "User stories",
			Answers = new()
			{
				"Tell",
				"Sell",
				"Consult",
				"Agree",
				"Advise",
				"Inquire",
				"Delegate"
			},
			Image = "/Images/truck-fast.svg"
		};
	}
}
