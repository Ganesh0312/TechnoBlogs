using System.ComponentModel.DataAnnotations;

namespace TechnoBlogs.Models.DTO
{
	public class Registration
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		[Required]
		[Compare("Password")]
		public string PasswordConform { get; set; }
		public string? Role { get; set; }

	}
}
