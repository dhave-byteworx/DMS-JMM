namespace MyDocU.Client;
using CommunityToolkit.Maui;
using Material.Components.Maui.Extensions;
using Microsoft.Extensions.DependencyInjection;
using SkiaSharp.Views.Maui.Controls.Hosting;
using ViewModels;
using Views;

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
			   })
			.UsePrism(PrismStartup.Configure);

		builder.UseMauiCommunityToolkit(options =>
		{
			options.SetShouldSuppressExceptionsInAnimations(true);
			options.SetShouldSuppressExceptionsInBehaviors(true);
			options.SetShouldSuppressExceptionsInConverters(true);
		});

		builder.UseMaterialComponents(new List<string>
			{
				"Montserrat-Regular.ttf",
				"Montserrat-Italic.ttf",
				"Montserrat-Medium.ttf",
				"Montserrat-MediumItalic.ttf",
				"Montserrat-Bold.ttf",
				"Montserrat-BoldItalic.ttf",
			});
		builder.UseSkiaSharp();
		builder.Services.AddMediatR(x =>
		{
			x.RegisterServicesFromAssemblies(typeof(MyDocU.Application.Commands.AuthenticateUserCommand).Assembly);
		});

		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddSingleton<LoginPage>();

		var app = builder.Build();
		return app;
	}

	private static string GetDatabaseConnectionString(string filename)
	{
		return $"Filename={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename)}.db";
	}

}