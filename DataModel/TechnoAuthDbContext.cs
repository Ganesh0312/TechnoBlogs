using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechnoBlogs.Models.Authenticate;

namespace TechnoBlogs.DataModel
{
	public class TechnoAuthDbContext : IdentityDbContext<ApplicationUser>
	{

		public TechnoAuthDbContext(DbContextOptions<TechnoAuthDbContext> options) :base(options)  
		{
			
		}

	}
}
