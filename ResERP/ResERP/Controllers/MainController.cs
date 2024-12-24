using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResERP.Data;
using ResERP.Models;

namespace ResERP.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        //Db Context
        private readonly AppDbContext _context;

        public MainController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddNewUser()
        {
            //Get Role Names
            var role = _context.Roles.Select(r => r.RoleName).ToList();

            //Send Role Names to ViewData
            ViewData["RoleName"] = role;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserList(int page = 1, int pageSize = 10)
        {
            var totalUsers = await _context.Accounts.CountAsync();
            var accounts = await _context.Accounts
                     .Skip((page - 1) * pageSize)
                     .Take(pageSize)
                     .ToListAsync();
            var personals = await _context.Personal.ToListAsync();
            var addresses = await _context.Address.ToListAsync();

            var UserList = accounts.Select(account =>
            {
                var personal = personals.FirstOrDefault(p => p.AccountID == account.AccountID);
                var address = addresses.FirstOrDefault(a => a.PersonalID == personal.PersonalID);

                return new NewUserViewModel
                {
                    AccountEmail = account.AccountEmail,
                    RoleID  =  account.RoleID,
                    FullName = personal.FullName,
                    DateBirth = personal.DateBirth,
                    PhoneNumber = personal.PhoneNumber,
                    StreetNumber = address.StreetNumber,
                    StreetAddress = address.StreetAddress,
                    City = address.City,
                    Province = address.Province,
                    PostalCode = address.PostalCode,
                    Country = address.Country,
                };
            }).ToList();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling(totalUsers / (double)pageSize);

            return View(UserList);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string email)
        {
            var user = await _context.Accounts.FirstOrDefaultAsync(u => u.AccountEmail == email);

            if ( user == null)
            {
                return NotFound();
            }
            _context.Accounts.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("UserList");

        }
    }
}
