using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnoBlogs.Models.ViewModel
{
	public class BlogPostView
	{
		public string Heading { get; set; }
		public string PageTitle { get; set; }
		public string Content { get; set; }
		public string ShortDescription { get; set; }
		public DateTime PublishedDate { get; set; }
		public string Author { get; set; }
		public bool Visible { get; set; }
	}
}
