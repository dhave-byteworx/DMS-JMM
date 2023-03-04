namespace MyDocU.Domain.Interfaces
{
	using MyDocU.Domain.Models;

	public interface IAuthenticationService
	{

		Task<AuthenticationResponse> SignIn(string username, string password);
	}
}
