namespace MyDocU.Client.ViewModels
{
	using Prism.Common;
	using Prism.Navigation;

	public class AddDocumentViewModel : RegionViewModelBase
	{
		public AddDocumentViewModel(INavigationService navigationService, IPageAccessor pageAccessor) : base(navigationService, pageAccessor)
		{
		}
	}
}
