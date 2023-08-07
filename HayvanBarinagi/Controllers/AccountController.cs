using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Claims;
using HayvanBarinagi.Models;
using HayvanBarinagi.Data;
using HayvanBarinagi.Models.Entities;

namespace HayvanBarinagi.Controllers
{
   
    public class AccountController : Controller
	{
		private readonly DatabaseContex _databaseContex;
        private object _databaseContext;
        private readonly IConfiguration _configuration;

        public AccountController(DatabaseContex databaseContex, IConfiguration configuration)
		{
			_databaseContex = databaseContex;
            _configuration = configuration;
        }
        [AllowAnonymous]
        public IActionResult Login()
		{
			return View();
		}
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				User user = _databaseContex.Users.FirstOrDefault(x => x.UserName.ToLower() == model.UserName.ToLower()&& x.Password == model.Password);

				if(user != null)
				{
                    //cookie authentication
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, user.NameSurname ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, user.Role ));
                    claims.Add(new Claim("Username", user.UserName));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");

                }
                else
				{
					ModelState.AddModelError("","Username or password is incorrect.");
				}
			}
            return View(model);
        }

		public IActionResult Register()
		{
			return View();
		}

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
				if(_databaseContex.Users.Any(x=> x.UserName.ToLower()== model.UserName.ToLower()))
				{
                    ModelState.AddModelError(nameof(model.UserName), "Username is already exists.");
                    return View(model);
                }
				User user = new()
				{
					UserName = model.UserName,
					Password = model.Password
				};

				_databaseContex.Users.Add(user);
			   int affectedRowCount = _databaseContex.SaveChanges();

				if(affectedRowCount ==0)
				{
					ModelState.AddModelError("", "User can not added.");
				}
				else
				{
					return RedirectToAction(nameof(Login));
				}
            }
            return View(model);
        }

        
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
