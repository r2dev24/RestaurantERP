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
        [HttpPost]
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

            var roleName = await _context.Roles.FirstOrDefaultAsync(r => r.RoleID == account.RoleID);

            //Define Claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim("Email", account.AccountEmail),
                new Claim("Role", roleName.RoleName)
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

        [HttpPost]
        public async Task<IActionResult> AddNewUser(NewUserViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return RedirectToAction("AddNewUser", "Main");
            }

            //add model to account
            var account = new Account
            {
                AccountEmail = model.AccountEmail,
                AccountPassword = model.AccountPassword,
                RoleID = model.RoleID,
            };

            try
            {
                await _context.Accounts.AddAsync(account);
                await _context.SaveChangesAsync();

                //add model to personal
                var personal = new Personal
                {
                    FullName = model.FullName,
                    DateBirth = model.DateBirth,
                    PhoneNumber = model.PhoneNumber,
                    AccountID = account.AccountID,
                };

                await _context.Personal.AddAsync(personal);
                await _context.SaveChangesAsync();

                //add model to address
                var address = new Address
                {
                    StreetNumber = model.StreetNumber,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    Province = model.Province,
                    PostalCode = model.PostalCode,
                    Country = model.Country,
                    PersonalID = personal.PersonalID,
                };

                await _context.Address.AddAsync(address);
                await _context.SaveChangesAsync();

                return RedirectToAction("UserList", "Main");
            }
            catch (Exception ex) 
            {
                return RedirectToAction("AddNewUser", "Main");
            }
        }
    }
}
