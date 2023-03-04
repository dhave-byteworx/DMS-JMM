namespace MyDocU.Client.ViewModels;

using System.Windows.Input;
using MediatR;
using MyDocU.Application.Commands;

public partial class LoginViewModel : BindableBase
{
	private readonly IRegionManager regionManager;
	private readonly IMediator mediator;

	public LoginViewModel(IRegionManager regionManager, IMediator mediator)
	{
		this.regionManager = regionManager;
		this.mediator = mediator;

		SubmitCommand = new DelegateCommand(Submit);

	}

	public string email;

	public string Email
	{
		get => email;
		set
		{
			SetProperty(ref email, value);
		}
	}

	public string password;

	public string Password
	{
		get => password;
		set
		{
			SetProperty(ref password, value);
		}
	}

	private async void Submit()
	{
		var command = new AuthenticateUserCommand
		{
			Username = Email,
			Password = Password,
		};

		var response = await mediator.Send(command);

		if (response.Response != null)
		{
			//User is authenticated
			//Navigate to Main Page
		}
		else
		{
			//Show error message - invalid username and password
		}
	}

	public ICommand SubmitCommand { get; private set; }
}
 