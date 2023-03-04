namespace MyDocU.Domain.Models
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security.Cryptography.X509Certificates;
	using System.Text;
	using System.Threading.Tasks;

	public class User
	{

		public string Id { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

	}
}
