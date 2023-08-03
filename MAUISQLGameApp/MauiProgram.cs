using MAUISQLGameApp.Data;
using Microsoft.Extensions.Logging;

namespace MAUISQLGameApp;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "AppDb.db");

		builder.Services.AddSingleton(x => ActivatorUtilities.CreateInstance<GameRepository>(x, dbPath));
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
