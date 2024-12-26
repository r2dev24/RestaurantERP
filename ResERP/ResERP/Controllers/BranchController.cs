using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResERP.Data;
using ResERP.Models;
using ResERP.Models.ViewModels;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ResERP.Controllers
{
    public class BranchController : Controller
    {
        //Db Context
        private readonly AppDbContext _context;

        //logger
        private readonly ILogger<BranchController> _logger;

        public BranchController(AppDbContext context, ILogger<BranchController> logger)
        {
            _context = context;
            _logger = logger;
        }

        //Main View
        public IActionResult Index()
        {
            return View();
        }

        //Add Branch View
        public IActionResult AddBranch()
        {
            return View();
        }

        //Add Branch Action
        public async Task<IActionResult> AddNewBranch(BranchAddressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogError($"ModelState Error: {error.ErrorMessage}");
                }
                return View("AddBranch", model);
            }


            //Get Current User email
            var user = User.FindFirst("Email")?.Value;
            if (user == null) 
            {
                _logger.LogError("User Null");
                return View("AddBranch", model);
            }

            //Get User Account ID
            var account_id = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountEmail == user);

            if (account_id == null)
            {
                _logger.LogError("account Null");
                return View("AddBranch", model);
            }

            var branch = new Branch
            {
                BranchName = model.BranchName,
                AccountID = account_id.AccountID,
            };

            try
            {
                await _context.Branches.AddAsync(branch);
                await _context.SaveChangesAsync();

                var branchAddress = new BranchAddress
                {
                    StreetNumber = model.StreetNumber,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    Province = model.Province,
                    Country = model.Country,
                    PostalCode = model.PostalCode,
                    BranchID = branch.BranchID,
                };

                await _context.BranchAdress.AddAsync(branchAddress);
                await _context.SaveChangesAsync();

                Console.WriteLine("Data Added");
                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Exception occurred: {ex.Message}");
                _logger.LogError($"Stack Trace: {ex.StackTrace}");
                return View("AddBranch", model);
            }
        }


    }
}
