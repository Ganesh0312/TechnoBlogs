using Microsoft.AspNetCore.Mvc;

namespace TechnoBlogs.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
