using Microsoft.AspNetCore.Mvc;

namespace ResERP.Controllers
{
    public class EmployeeController : Controller
    {
        //Add New Employee View
        public IActionResult AddEmployee()
        {
            return View();
        }
    }
}
