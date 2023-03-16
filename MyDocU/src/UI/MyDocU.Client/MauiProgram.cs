namespace MyDocU.Client;

using CommunityToolkit.Maui;
using FluentValidation;
using Material.Components.Maui.Extensions;
using Microsoft.Extensions.DependencyInjection;
using MyDocU.Client.ViewModels;
using MyDocU.Client.Views;
using MyDocU.Domain.Interfaces;
using MyDocU.Domain.Models.Validators;
using MyDocU.Infrastructure.Services.Mocks;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation;
using SkiaSharp.Views.Maui.Controls.Hosting;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UsePrism(prism =>
			{
				prism
				.ConfigureModuleCatalog(moduleCatalog =>
				{
					moduleCatalog.AddModule<MyDocUModule>();
				})
				.RegisterTypes(containerRegistry =>
				{
					containerRegistry.RegisterSingleton<IAuthenticationService, MockAuthenticationService>();
					containerRegistry.RegisterForNavigation<SplashPage, SplashPageViewModel>();
					containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
					containerRegistry.RegisterSingleton<IValidator<LoginPageViewModel>, LogInValidator>();
				})
				.OnAppStart(navigationService => navigationService.CreateBuilder()
					.AddSegment<SplashPageViewModel>()
					.NavigateAsync(HandleNavigationError));
			});


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

		var app = builder.Build();
		return app;
	}

	private static string GetDatabaseConnectionString(string filename)
	{
		return $"Filename={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename)}.db";
	}

	private static void HandleNavigationError(Exception ex)
	{
		Console.WriteLine(ex);
		System.Diagnostics.Debugger.Break();
	}
}