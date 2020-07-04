using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using InitCMS.Models;
using InitCMS.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Update;

namespace InitCMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel) 
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registerViewModel.Email, Email = registerViewModel.Email };
                var result = await userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Store");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View(registerViewModel);
        }
        //LogOut 
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Store");       
        }
        //Login View
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, false);

                if (result.Succeeded)
                {
                  return RedirectToAction("Index", "Store");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt!");
                
            }
            return View(loginViewModel);
        }
        //Remote Validate of UserEmail
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyEmail(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else 
            {
                return Json($"Email {email} is already in use!");
            }
        
        }


    }
}
