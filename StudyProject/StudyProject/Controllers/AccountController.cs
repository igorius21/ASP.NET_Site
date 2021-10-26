using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudyProject.Models;

namespace StudyProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> managerUser;
        private readonly SignInManager<IdentityUser> managerIn;
        public AccountController(UserManager<IdentityUser> managUser, SignInManager<IdentityUser> managIn)
        {
            managerUser = managUser;
            managerIn = managIn;
        }

        [AllowAnonymous]
        public IActionResult Login(string urlReturn)
        {
            ViewBag.returnUrl = urlReturn;
            return View(new LoginView());
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginView mod, string urlReturn)
        {
            if (ModelState.IsValid)
            {
                IdentityUser us = await managerUser.FindByNameAsync(mod.AdminName);
                if (us != null)
                {
                    await managerIn.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult res = await managerIn.PasswordSignInAsync(us, mod.AdminPassword, mod.AdminRemember, false);
                    if (res.Succeeded)
                    {
                        return Redirect(urlReturn ?? "/admin");
                    }
                }
                ModelState.AddModelError(nameof(LoginView.AdminName), "Неверные данные");
            }
            return View(mod);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await managerIn.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
    }
}