using HaiSan.DI;
using HaiSan.Models.View;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HaiSan.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        
        public UserController(IUserService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [Route("/user/login")]
        public IActionResult Login(string ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/user/login")]
        public async Task<IActionResult> Login(LoginModel request, string ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            if (ModelState.IsValid)
            {
                var user = _service.Login(request);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim("Ten", user.Ten == null ? "Anonymous" : user.Ten),
                        new Claim(ClaimTypes.Role, user.RoleId),
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        //IsPersistent = true,
                        IsPersistent = request.RememberMe
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                        );
                    if (Url.IsLocalUrl(ReturnUrl))
                        return Redirect(ReturnUrl);
                    else
                        return RedirectToAction("index", "home");
                }
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(request);
            }
            return View(request);
        }
        [Route("/user/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login", "user");
        }

        [AllowAnonymous]
        [Route("/user/register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel user)
        {
            if (user.Username != null)
            {
                var usrname = await _service.GetUserByUserName(user.Username);
                if (usrname != null)
                {
                    ModelState.AddModelError("Available", "Tài khoản đã tồn tại!");
                    return View(user);
                }
            }
            if (ModelState.IsValid)
            {
                await _service.Register(user);
                return RedirectToAction("login");
            }
            return View();
        }

        [Route("/user/{transaction}")]
        public async Task<IActionResult> Transaction(string transaction)
        {
            var userId = User.Identity.Name;
            var action = transaction.ToLower();
            if (action == "pending")    return View(await _service.GetAllProductsByActionAsync(userId, 0));
            if (action == "shiping")    return View(await _service.GetAllProductsByActionAsync(userId, 1));
            return NotFound();
        }
        [Route("/user/completed")]
        public async Task<IActionResult> Completed()
        {
            var userId = User.Identity.Name;
            var list1 = await _service.GetAllProductsByActionAsync(userId, 2);
            var list2 = await _service.GetAllProductsByActionAsync(userId, 3);
            list1.AddRange(list2);
            return View(list1);
        }
    }
}
