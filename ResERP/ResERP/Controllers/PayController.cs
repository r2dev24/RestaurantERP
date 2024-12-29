using Microsoft.AspNetCore.Mvc;
using ResERP.Data;
using ResERP.Models;

namespace ResERP.Controllers
{
    public class PayController : Controller
    {
        //Db Context
        private readonly AppDbContext _context;

        //Constructor
        public PayController(AppDbContext context)
        {
            _context = context;
        }

        //Pay View
        public IActionResult Payroll()
        {
            // Branch Members From DB
            var member = _context.BranchMembers.ToList();

            ViewData["MemberList"] = member;

            return View();
        }


    }
}
