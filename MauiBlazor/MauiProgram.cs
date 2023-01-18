using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MauiBlazor.SignalR;
using System.Reflection;

namespace MauiBlazor;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});
		var a = Assembly.GetExecutingAssembly();
		using var stream = a.GetManifestResourceStream("MauiBlazor.appsettings.json");
		var config = new ConfigurationBuilder()
			.AddJsonStream(stream)
			.Build();
		builder.Configuration.AddConfiguration(config);

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddSingleton<ISignalrContext>(new SignalrContext(config));
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
