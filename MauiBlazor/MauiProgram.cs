using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MauiBlazor.SignalR;

namespace MauiBlazor;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		IConfiguration configuration = new ConfigurationBuilder()
							.AddJsonFile("appsettings.json")
							.Build();

		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddSingleton<ISignalrContext>(new SignalrContext(configuration));
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
