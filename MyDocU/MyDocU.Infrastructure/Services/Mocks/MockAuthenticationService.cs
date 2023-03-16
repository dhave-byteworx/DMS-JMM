namespace MyDocU.Infrastructure.Services.Mocks
{
	using System.Threading.Tasks;
	using MyDocU.Domain.Interfaces;
	using MyDocU.Domain.Models;

	public class MockAuthenticationService : IAuthenticationService
	{

		private List<User> users = new List<User>()
		{
			new User { Id ="1234", Email = "jmm@gmail.com", Password = "123" },
			new User { Id ="4321", Email = "cc@gmail.com", Password = "1234" }

		};

		public Task<AuthenticationResponse> SignIn(string username, string password)
		{
			var user = users.FirstOrDefault(x => x.Email.Equals(username, StringComparison.OrdinalIgnoreCase) && x.Password == password);

			if (user != null)
			{
				return Task.FromResult(new AuthenticationResponse
				{
					UserId = user.Id,
					AccessToken = "accesstoken",
				});
			}

			return Task.FromResult(default(AuthenticationResponse));
		}
	}
}
