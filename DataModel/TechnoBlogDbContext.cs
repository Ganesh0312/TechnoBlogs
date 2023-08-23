using Microsoft.EntityFrameworkCore;
using TechnoBlogs.Models.Domain;

namespace TechnoBlogs.DataModel
{
	public class TechnoBlogDbContext : DbContext
	{
		public TechnoBlogDbContext(DbContextOptions<TechnoBlogDbContext> options) : base(options) 
		{ 

		}

		public DbSet<BlogPost> Posts { get; set; }

	}
}
