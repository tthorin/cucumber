using _SharedSignalR.Models;
using Microsoft.Extensions.Configuration;

namespace MauiBlazor.SignalR
{
	internal interface ISignalrContext
	{
		public UserSettings Settings { get; set; }
		Task Start();
		ValueTask DisposeAsync();
		Task SendPokerVote(string vote);
		Task SendPokerQuestion(string feature);
		Task Join();
		void OnPokerQuestion(Action<PokerObject> action);
		void OnJoin(Action<JoinRoomData> action);
		void OnPokerVote(Action<PokerVote> action);
	}
}