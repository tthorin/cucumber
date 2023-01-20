namespace MauiBlazor.SignalR;

using _SharedSignalR.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using _SharedSignalR.Models.EventModels;
using _SharedSignalR.Enums;
internal class SignalrContext : ISignalrContext
{
	const string URL = "https://localhost:7242/signalr";

	public UserSettings Settings { get; set; } = new();

	readonly HubConnection connection;
	public bool Connected { get; private set; }

	readonly IConfiguration _configuration;

	public SignalrContext(IConfiguration configuration)
	{
		_configuration = configuration;

		var cnnStr = GetConnectionString();
		connection = new HubConnectionBuilder()
					.WithUrl(cnnStr ?? URL)
					.WithAutomaticReconnect()
					.Build();
	}

	private string GetConnectionString()
	{
		if (DeviceInfo.Platform == DevicePlatform.Android)
			return _configuration.GetConnectionString("SignalrAndroid");
		else
			return _configuration.GetConnectionString("Signalr");
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

	public async Task<bool> GroupNameExists(string groupName)
	{
		return Connected && await connection.InvokeAsync<bool>("GroupNameExists", groupName);
	}
	public async Task<bool> AddGroupName(string groupName)
	{
		return Connected && await connection.InvokeAsync<bool>("AddGroupName", groupName);
	}

	public IDisposable OnPokerQuestion(Action<PokerObject> action) => connection.On<PokerObject>("PokerQuestion", action.Invoke);
	public IDisposable OnPokerVote(Action<PokerVote> action) => connection.On<PokerVote>("PokerAnswer", action.Invoke);
	public IDisposable OnPokerResults(Action<PokerVoteResults> action) => connection.On<PokerVoteResults>("PokerResults", action.Invoke);

	public IDisposable OnJoin(Action<JoinRoomData> action) => connection.On<JoinRoomData>("JoinRoom", action.Invoke);

	public IDisposable OnNavigation(Action<NavigationObject> action) => connection.On<NavigationObject>("Navigation", action.Invoke);

	public IDisposable OnRoomNamesInUse(Action<HashSet<string>> action) =>connection.On<HashSet<string>>("RoomNamesInUse",action.Invoke);
	public async Task SendPokerVote(string vote)
	{
		var pokerVoteData = new PokerVote
		{
			Username = Settings.Username,
			Answer = vote,
			RoomName = Settings.Room
		};

		if (Connected)
			await connection.SendAsync("PokerVote", pokerVoteData);
	}

	public async Task SendPokerQuestion(PokerObject question)
	{
		if (Connected)
			await connection.SendAsync("PokerQuestion", question);
	}

	public async Task JoinRoom()
	{
		if (Connected)
			await connection.SendAsync("JoinRoom", new JoinRoomData { User = Settings });
	}

	public async Task SendNavigationObject(Pages navigation)
	{
		NavigationObject nav = new() { Page = navigation };
		if (Connected)
			await connection.SendAsync("Navigation", nav);
	}
	public async ValueTask DisposeAsync()
	{
		if (connection is not null)
		{
			await connection.DisposeAsync();
		}
	}

	public async Task SendPokerVoteResult(PokerVoteResults results)
	{
		if (Connected)
			await connection.SendAsync("PokerResults", results);
	}

	public async Task GetRoomNamesInUse()
	{
		if (Connected)
			await connection.SendAsync("GetRoomNamesInUse");
	}

}
