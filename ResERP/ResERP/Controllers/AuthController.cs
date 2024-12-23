using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResERP.Data;
using ResERP.Models;
using System.Security.Claims;

namespace ResERP.Controllers
{
    public class AuthController : Controller
    {
        //Db Context
        private readonly AppDbContext _context;

        //Constructor
        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        //Sign In
        public async Task<IActionResult> SignIn(Account model)
        {
            //Check ModelState
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Account", "The user account is invalid.");
                return RedirectToAction("Index", "Home");
            }

            //Get User Account
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountEmail == model.AccountEmail && a.AccountPassword == model.AccountPassword);

            //Check Account is valid
            if (account == null)
            {
                ModelState.AddModelError("Account", "The user account is invalid.");
                return RedirectToAction("Index", "Home");
            }

            //Get User Information
            var user = await _context.Personal.FirstOrDefaultAsync(u => u.AccountID == account.AccountID);

            if (user == null)
            {
                ModelState.AddModelError("Account", "The user account is invalid.");
                return RedirectToAction("Index", "Home");
            }

            //Define Claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim("Email", account.AccountEmail)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Main");
        }

        //Sign Out
        public async Task<IActionResult> SignOut()
        {
            // Delete Session
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

          
            return RedirectToAction("Index", "Home");
        }
    }
}
