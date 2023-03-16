namespace MyDocU.Client.ViewModels
{
	using System;
	using System.Windows.Input;
	using Prism.Commands;
	using Prism.Common;
	using Prism.Navigation;
	using Prism.Regions;

	public class MenuViewModel : RegionViewModelBase
	{
		private readonly IRegionManager regionManager;

		public MenuViewModel(INavigationService navigationService, IRegionManager regionManager, IPageAccessor pageAccessor) : base(navigationService, pageAccessor)
		{
			this.regionManager = regionManager;

			NavigateToDocumentsCommand = new DelegateCommand(NavigateToDocuments);
			NavigateToAddDocumentCommand = new DelegateCommand(NavigateToAddDocument);
		}

		private void NavigateToDocuments()
		{
			regionManager.RequestNavigate("FullDetailRegion", "FullDetailView");
		}

		private void NavigateToAddDocument()
		{
			regionManager.RequestNavigate("FullDetailRegion", "AddDocumentView");
		}

		public ICommand NavigateToDocumentsCommand { get; private set; }

		public ICommand NavigateToAddDocumentCommand { get; private set; }
	}
}
