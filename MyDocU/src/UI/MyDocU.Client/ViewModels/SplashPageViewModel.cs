namespace MyDocU.Client.ViewModels
{
	using Prism.AppModel;
	using Prism.Navigation;

	public class SplashPageViewModel : IPageLifecycleAware
	{

		private INavigationService _navigationService { get; }

		public SplashPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		public async void OnAppearing()
		{
			await Task.Delay(TimeSpan.FromSeconds(5));
			_navigationService.CreateBuilder()
				.UseAbsoluteNavigation()
				.AddSegment<LoginPageViewModel>()
				.Navigate();
		}

		public void OnDisappearing()
		{

		}
	}
}
