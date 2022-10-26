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
        public async Task<IActionResult> Index(LoginDto loginDto,string ReturnUrl=null)
        {
            ReturnUrl = ReturnUrl ?? Url.Action("Index", "Home");

            if (ModelState.IsValid)
            {
                var hasUser = await _UserManager.FindByEmailAsync(loginDto.Email);
                if (hasUser != null)
                {
                   // await _SignInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _SignInManager.PasswordSignInAsync(hasUser, loginDto.Password, false, false);
                    if (result.Succeeded)
                    {
                    return Redirect(ReturnUrl);
                    }
                }
                else
                {
   ModelState.AddModelError(string.Empty, "Error Mail or Password");
                }
            }
            return View();
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
        public async Task<IActionResult> SignUp(CreatedUser createdUser)
        {
            UserApp userApp = new UserApp() { UserName=createdUser.UserName, Email=createdUser.Email, PhoneNumber=createdUser.PhoneNumber };
           IdentityResult result=  await _UserManager.CreateAsync(userApp, createdUser.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View(createdUser);
        }
    }
}
