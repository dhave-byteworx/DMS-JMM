namespace MyDocU.Domain.Models.Validators
{
	using FluentValidation;
	using MyDocU.Client.ViewModels;

	public class LogInValidator : AbstractValidator<LoginPageViewModel>
	{
		public LogInValidator()
		{

			RuleFor(x => x.Email)
				.EmailAddress().WithMessage("Please enter a valid email");
			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Password is required");
		}
	}

}
