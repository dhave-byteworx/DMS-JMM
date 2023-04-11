namespace MyDocU.Client.ViewModels;

using System;
using System.ComponentModel;
using System.Windows.Input;
using FluentValidation;
using MediatR;
using Microsoft.Maui.Controls;
using MyDocU.Application.Commands;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions;

public partial class LoginPageViewModel : BindableBase
{
	public ICommand SubmitCommand { get; private set; }
	public ICommand TogglePasswordVisibilityCommand { get; private set; }

	private readonly IRegionManager regionManager;
	private readonly IMediator mediator;
	private readonly IValidator<LoginPageViewModel> validator;
	private readonly INavigationService navigationService;

	public LoginPageViewModel(
		IRegionManager regionManager,
		IMediator mediator,
		IValidator<LoginPageViewModel> validator,
		INavigationService navigationService)
	{
		this.regionManager = regionManager;
		this.mediator = mediator;
		this.validator = validator;
		this.navigationService = navigationService;

		SubmitCommand = new DelegateCommand(Submit);
		TogglePasswordVisibilityCommand = new Command<Entry>((entry) =>
		{
			entry.IsPassword = !entry.IsPassword;

		});

	}

	private string email;
	private string password;
	private string emailTextIsValid;
	private string passwordIsValid;

	public bool CanLogin
	{
		get
		{
			var validationResult = validator.Validate(this);
			return validationResult.IsValid;

		}
	}

	public bool PasswordEntered
	{
		get
		{
			var passwordValidation = validator.Validate(this);
			return passwordValidation.IsValid;

		}
	}


	public string EmailValidationText
	{
		get => emailTextIsValid;
		set
		{
			SetProperty(ref emailTextIsValid, value);
			RaisePropertyChanged(nameof(CanLogin));
		}
	}

	public string Email
	{
		get => email;
		set
		{
			SetProperty(ref email, value);
			RaisePropertyChanged(nameof(CanLogin));
			var validationResult = validator.Validate(this);	

			if (!validationResult.IsValid)
			{
				var error = validationResult.Errors.FirstOrDefault(e => e.PropertyName == nameof(Email));

				if (error != null)
				{
					EmailValidationText = error.ErrorMessage;
					return;
				}
			}

			EmailValidationText = string.Empty;
		}
	}

	public string Password
	{
		get => password;
		set
		{
			SetProperty(ref password, value);
			RaisePropertyChanged(nameof(CanLogin));
			if(!string.IsNullOrEmpty(Password))
			{
				PasswordValidation = string.Empty;
			}
			else
			{
				PasswordValidation = "Password is required";
				return;
			}
		}
	}

	public string PasswordValidation
	{
		get => passwordIsValid;
		set
		{
			SetProperty(ref passwordIsValid, value);
			RaisePropertyChanged(nameof(CanLogin));

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
			navigationService.NavigateAsync("/ShellPage")
				.OnNavigationError(ex => Console.WriteLine(ex));

		}
		else
		{
			//Show error message - invalid username and password
		}
	}

	
}
 