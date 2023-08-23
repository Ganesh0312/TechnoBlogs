using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnoBlogs.DataModel;

namespace TechnoBlogs.Controllers
{
    /*[Authorize]*/
    public class DashboardController : Controller
    {
        public TechnoBlogDbContext _context;

        public DashboardController(TechnoBlogDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Display()
        {
            var blogs = await _context.Posts.ToListAsync();
            return View(blogs);
        }


    }
}
