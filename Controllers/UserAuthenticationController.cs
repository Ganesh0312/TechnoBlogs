using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnoBlogs.Models.DTO;
using TechnoBlogs.Repositories.Abstract;

namespace TechnoBlogs.Controllers
{
	public class UserAuthenticationController : Controller
	{
        private readonly IUserAuthenticationService _service;
        public UserAuthenticationController(IUserAuthenticationService service)
		{
			_service = service;
		}
		
		public IActionResult Registration()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Registration(Registration model)
		{
			if(!ModelState.IsValid)
				return View(model);
			model.Role = "user";
			var result = await _service.RegistrationAsync(model);
			TempData["msg"] = result.Message;
			return RedirectToAction(nameof(Registration));
		}

        public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(Login model)
		{
			if(!ModelState.IsValid)
			{
				return View(model);
			}
			var result = await _service.LoginAsync(model);
			if(result.StatusCode == 1)
			{
				return RedirectToAction("Display", "Dashboard");
			}
			else
			{
				TempData["msg"] = result.Message;
				return RedirectToAction(nameof(Login));
			}
		}

		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await _service.LogoutAsync();
			return RedirectToAction(nameof(Login));
		}

		/*public async Task<IActionResult> Reg()
		{
			var model = new Registration
			{
				Username = "Ganesh03",
				Name = "Ganesh Bobade",
				Email = "ganesh123@gmail.com",
				Password = "Ganesh@123"
			};
			model.Role = "admin";
			var result = await _service.RegistrationAsync(model);
			return Ok(result);
		}*/
	}
}
