using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{
	[Authorize]
	public class AccountController(UserManager<IdentityUser> userManager, 
								   SignInManager<IdentityUser> signInManager) 
		: Controller
	{
		private readonly UserManager<IdentityUser> userManager = userManager;
		private readonly SignInManager<IdentityUser> signInManager = signInManager;

		[AllowAnonymous]
		public IActionResult Login(string returnUrl)
		{
			ViewBag.returnUrl = returnUrl;
			return View(new LoginViewModel());
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				IdentityUser? user = await userManager.FindByNameAsync(model.UserName);
				if (user != null)
				{
					await signInManager.SignOutAsync();
					Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

					if (result.Succeeded)
						return Redirect(returnUrl ?? "/");
				}

                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");
            }
            return Login(returnUrl);
		}

		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Admin");
		}
	}
}
