namespace MauiBlazor.SignalR
{
	using _SharedSignalR.Models;
	using MauiBlazor.Pages.Poker;
	using Microsoft.AspNetCore.SignalR.Client;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Microsoft.Extensions.Configuration;
	using System.Diagnostics;

	internal class SignalrContext : ISignalrContext
	{
		const string URL = "https://localhost:7242/signalr";

		public UserSettings Settings { get; set; }
		HubConnection connection;
		public bool Connected { get; private set; }
		IConfiguration _configuration;

		public SignalrContext(IConfiguration configuration)
		{
			_configuration = configuration;

			connection = new HubConnectionBuilder()
						.WithUrl(_configuration.GetConnectionString("Signalr") ?? URL)
						.WithAutomaticReconnect()
						.Build();
		}

		public async Task Start()
		{
			try
			{
				await connection.StartAsync();
				Connected = true;
			}
			catch
			{
				Debug.WriteLine("Could not connect to signalR hub.");
			}
		}

		public IDisposable OnPokerQuestion(Action<PokerObject> action) => connection.On<PokerObject>("PokerQuestion", action.Invoke);
		public IDisposable OnPokerVote(Action<PokerVote> action) => connection.On<PokerVote>("PokerAnswer", action.Invoke);
		public IDisposable OnPokerResults(Action<PokerVoteResults> action) => connection.On<PokerVoteResults>("PokerResults", action.Invoke);

		public IDisposable OnJoin(Action<JoinRoomData> action) => connection.On<JoinRoomData>("Join", action.Invoke);

		public async Task SendPokerVote(string vote)
		{

			var pokerVoteData = new PokerVote
			{
				Username = Settings.Username,
				Answer = vote,
				RoomName = Settings.Room
			};

			if(Connected)
				await connection.SendAsync("Vote", pokerVoteData);
		}

		public async Task SendPokerQuestion(PokerObject question)
		{
			if (Connected)
				await connection.SendAsync("PokerQuestion", question);
		}

		public async Task Join()
		{
			if (Connected)
				await connection.SendAsync("JoinRoom", new JoinRoomData { User = Settings });
		}

		public async ValueTask DisposeAsync()
		{
			if (connection is not null)
			{
				await connection.DisposeAsync();
			}
		}
	}
}
