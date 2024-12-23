using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResERP.Data;

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

        public IActionResult UserList() 
        {
            return View();
        }
    }
}
