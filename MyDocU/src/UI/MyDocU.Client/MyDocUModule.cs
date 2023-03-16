namespace MyDocU.Client
{
	using MyDocU.Client.ViewModels;
	using MyDocU.Client.Views;
	using Prism.Ioc;
	using Prism.Modularity;
	using Prism.Regions;

	public class MyDocUModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var regionManager = containerProvider.Resolve<IRegionManager>();

			regionManager.RegisterViewWithRegion("FullDetailRegion", "FullDetailView");
			regionManager.RegisterViewWithRegion("MenuRegion", "MenuView");
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry
				.RegisterForNavigation<ShellPage>() //contain regions
				.RegisterForRegionNavigation<MenuView, MenuViewModel>()
				.RegisterForRegionNavigation<FullDetailView, FullDetailViewModel>()
				.RegisterForRegionNavigation<AddDocumentView, AddDocumentViewModel>();
		}
	}
}
