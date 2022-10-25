using CoreLayer.Dtos.User;
using CoreLayer.Entities.UserEntity;
using IdentityApp.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<UserApp> _UserManager;
        private readonly SignInManager<UserApp> _SignInManager;
        public LoginController(UserManager<UserApp> UserManager, SignInManager<UserApp> signInManager)
        {
            _UserManager = UserManager;
            _SignInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var hasUser = await _UserManager.FindByEmailAsync(loginDto.Email);
            if (hasUser==null)
            {
                ModelState.AddModelError("", "Error Mail or Password");
                return View();
            }
           // await _SignInManager.SignOutAsync();
            var signInResult = await _SignInManager.PasswordSignInAsync(hasUser, loginDto.Password,false, false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Error Mail or Password");
                return View();
            }
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(CreatedUser createdUser)
        {
            return RedirectToAction("Index");
        }
    }
}
