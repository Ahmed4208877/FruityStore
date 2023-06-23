using fruity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fruity.Controllers
{
    public class UserController : Controller
    {
        UserManager<ApplicationUser> Usermanager;
        SignInManager<ApplicationUser> signInManager;
        public UserController(UserManager<ApplicationUser> manager ,SignInManager<ApplicationUser> signManager)
        {
            Usermanager = manager;
            signInManager = signManager;
        }


        public IActionResult Login(string returnurl)
        {
            return View(new UserModel() { 
               Returnurl=returnurl
            });
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public async Task< IActionResult> Loginwith(UserModel userModel)
        {
            var result = await signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, true, true);
            if (string.IsNullOrEmpty(userModel.Returnurl))
                userModel.Returnurl = "~/";
            if (result.Succeeded)
            {
                return Redirect(userModel.Returnurl);
            }else
                return View("Login",userModel);
        }
       




        public async Task <IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return Redirect("~/");
        }




        public IActionResult Register()
        {
            return View(new UserModel());
        }
        [HttpPost]
        public async Task<IActionResult> Registerwith(UserModel userModel)
        {
            var user = new ApplicationUser()
            {
                Email = userModel.Email,
                UserName = userModel.UserName
            };
            var result = await Usermanager.CreateAsync(user, userModel.Password);
            if (result.Succeeded)
            {
                return Redirect("Login");
            }
            else
                return View("Register", userModel);
        }
    }
}
