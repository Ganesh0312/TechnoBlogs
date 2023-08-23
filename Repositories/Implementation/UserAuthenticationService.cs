using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TechnoBlogs.Models.Authenticate;
using TechnoBlogs.Models.DTO;
using TechnoBlogs.Repositories.Abstract;

namespace TechnoBlogs.Repositories.Implementation
{
	public class UserAuthenticationService : IUserAuthenticationService
	{
		public readonly SignInManager<ApplicationUser> signInManager;
		public readonly UserManager<ApplicationUser> userManager;
		public readonly RoleManager<IdentityRole> roleManager;

		public UserAuthenticationService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			this.signInManager = signInManager;
			this.userManager = userManager;
			this.roleManager = roleManager;
		}

		public async Task<Status> LoginAsync(Login model)
		{
			var status = new Status();
			var user = await userManager.FindByNameAsync(model.Username);
			if(user == null)
			{
				status.StatusCode = 0;
				status.Message = "Invalid UserName";
				return status;
			}

			
			if (!await userManager.CheckPasswordAsync(user,model.Password))
			{
				status.StatusCode = 0;
				status.Message = "Invalid Password";
				return status;
			}

			var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, true);
			if (signInResult.Succeeded)
			{
				var userRoles= await userManager.GetRolesAsync(user);
				var authClaims = new List<Claim>
				{
					new Claim(ClaimTypes.Name,user.UserName)
				};
				foreach(var userRole in userRoles)
				{
					authClaims.Add(new Claim(ClaimTypes.Name, userRole));
				}
				status.StatusCode = 1;
				status.Message = "Logged in successfull";
				return status;
			}
			else if(signInResult.IsLockedOut)
			{
				status.StatusCode = 0;
				status.Message = "User Loked Out";
				return status;
			}
			else
			{
				status.StatusCode = 0;
				status.Message = "Error In Loggin In ";
				return status;
			}

		}

		public async Task LogoutAsync()
		{
			await signInManager.SignOutAsync();
		}

		public async Task<Status> RegistrationAsync(Registration model)
		{
			var status = new Status();
			var userExist = await userManager.FindByNameAsync(model.Username);
			if (userExist != null)
			{
				status.StatusCode = 0;
				status.Message = "User Allready Exists";
				return status;
			}

			ApplicationUser user = new ApplicationUser()
			{
				SecurityStamp = Guid.NewGuid().ToString(),
				Name = model.Name,
				Email = model.Email,
				UserName = model.Username,
				EmailConfirmed = true,
			};
			var result = await userManager.CreateAsync(user,model.Password);
			if(!result.Succeeded)
			{
				status.StatusCode=0;
				status.Message = "User Creation Failed";
				return status;
			}

			//role mannagement
			if (!await roleManager.RoleExistsAsync(model.Role))
				await roleManager.CreateAsync(new IdentityRole(model.Role));

			if(await roleManager.RoleExistsAsync(model.Role))
			{
				await userManager.AddToRoleAsync(user, model.Role);
			}

			status.StatusCode = 1;
			status.Message = "User Has Registerd Successfully";
			return status;
		}
	}
}
