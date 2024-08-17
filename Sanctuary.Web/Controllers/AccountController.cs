using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sanctuary.Data.Models.UserTables;
using Sanctuary.Data;
using Sanctuary.Web.Views.ViewModels;

namespace Sanctuary.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<BaseApplicationUser> UserManager;
        private SignInManager<BaseApplicationUser> SignInManager;
        private ApplicationDbContext ApplicationDbContext;

        public AccountController(UserManager<BaseApplicationUser> userManager, SignInManager<BaseApplicationUser> signInManager, ApplicationDbContext applicationDbContext)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            ApplicationDbContext = applicationDbContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new BaseApplicationUser()
            {
                FirstName = model.FirstName!,
                LastName = model.LastName!,
                Email = model.Email,
                UserName = model.Email,
            };

            var creationResult = await UserManager.CreateAsync(user, model.Password);

            if (creationResult.Succeeded)
            {
                return RedirectToAction("LogIn");
            }

            foreach (IdentityError error in creationResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LogInViewModel userLogInModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userLogInModel);
            }

            var user = await UserManager.FindByEmailAsync(userLogInModel.Email);

            var resultFromLogIn = await SignInManager.PasswordSignInAsync(user, userLogInModel.Password, isPersistent: false, lockoutOnFailure: false);

            if (resultFromLogIn.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login");
;
            return View(userLogInModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
