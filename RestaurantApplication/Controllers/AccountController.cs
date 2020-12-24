using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApplication.Models;
using RestaurantApplication.ViewModels;

namespace RestaurantApplication.Controllers
{
    public class AccountController : Controller
    {       
       
        private RestaurantDBContext restaurantService;
        public AccountController(RestaurantDBContext context)
        {
            restaurantService = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            if (ModelState.IsValid)
            {
                User user = await restaurantService.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                   
                    user = new User { Email = model.Email, Password = model.Password };
                    Role userRole = await restaurantService.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;

                    restaurantService.Users.Add(user);
                    await restaurantService.SaveChangesAsync();

                    await Authenticate(user); 

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Данный емейл уже используется");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            if (ModelState.IsValid)
            {
                User user = await restaurantService.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            ViewBag.email = Email();
            ViewBag.role = Role();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        private string Role()
        {
            string _role;
            try
            {
                _role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            }

            catch
            {
                _role = "user";
            }
            return _role;
        }

        private string Email()
        {
            string _email;
            try
            {
                _email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            }

            catch
            {
                _email = "";
            }
            return _email;
        }
    }
}
