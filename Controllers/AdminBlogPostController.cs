using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnoBlogs.DataModel;
using TechnoBlogs.Models.Domain;
using TechnoBlogs.Models.ViewModel;

namespace TechnoBlogs.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminBlogPostController : Controller
	{
		/*public readonly IWebHostEnvironment _webHostEnvironment;
		public readonly TechnoBlogDbContext _context;

		public AdminBlogPostController(IWebHostEnvironment webHostEnvironment, TechnoBlogDbContext context)
		{
			_webHostEnvironment = webHostEnvironment;
			_context = context;
		}*/
		
		public IActionResult Display()
		{
			return View();
		}
/*
		[HttpPost]
		public async Task<IActionResult> AddPost(BlogPostView model)
		{
				if (ModelState.IsValid)
				{
					// Map view model to model
					var blogPost = new BlogPost
					{
						Heading = model.Heading,
						PageTitle = model.PageTitle,
						Content = model.Content,
						ShortDescription= model.ShortDescription,
						PublishedDate= model.PublishedDate,
						Author = model.Author,
						Visible= model.Visible
					};

					// Handle image upload
					if (model.ImageFile != null)
					{
						var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
						var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
						var filePath = Path.Combine(uploadsFolder, uniqueFileName);
						await model.ImageFile.CopyToAsync(new FileStream(filePath, FileMode.Create));
						blogPost.ImageUrl = "/uploads/" + uniqueFileName;
					}
					_context.Posts.Add(blogPost);
					await _context.SaveChangesAsync();

					return RedirectToAction("Display", "AdminBlogPost"); 
				}
				return View(model);
			
		}*/
	}
}
