namespace MyDocU.Client
{
	using MyDocU.Client.ViewModels;
	using MyDocU.Client.Views;


	internal class PrismStartup
	{

		public static void Configure(PrismAppBuilder builder)
		{
			builder.RegisterTypes(RegisterTypes)
					.OnAppStart("NavigationPage/LoginPage");
		}

		private static void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>()
				.RegisterInstance(SemanticScreenReader.Default);
		}
	}
}
