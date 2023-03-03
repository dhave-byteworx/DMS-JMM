namespace MyDocU.Client.ViewModels;

using System;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public partial class LoginViewModel : BindableBase
{
	private readonly IRegionManager regionManager;

	public LoginViewModel(IRegionManager regionManager)
	{
		this.regionManager = regionManager;

		SubmitCommand = new DelegateCommand(Submit);

	}

	public string Email { get; set; }

	public string Password { get; set; }

	private void Submit()
	{

	}

	public ICommand SubmitCommand { get; private set; }
}
 