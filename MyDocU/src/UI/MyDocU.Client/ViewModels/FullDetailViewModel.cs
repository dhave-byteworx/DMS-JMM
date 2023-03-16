namespace MyDocU.Client.ViewModels
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Prism.Common;
	using Prism.Navigation;

	public class FullDetailViewModel : RegionViewModelBase
	{
		public FullDetailViewModel(INavigationService navigationService, IPageAccessor pageAccessor) : base(navigationService, pageAccessor)
		{
		}
	}
}
