using Microsoft.AspNetCore.Mvc;

namespace ResERP.Controllers
{
    public class BranchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBranch()
        {
            return View();
        }
    }
}
