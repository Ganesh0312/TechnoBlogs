using Microsoft.AspNetCore.Identity;

namespace TechnoBlogs.Models.Authenticate
{
	public class ApplicationUser : IdentityUser
	{
		public string Name { get; set; }
		public string? ProfilePicture { get; set; } 
	}
}
