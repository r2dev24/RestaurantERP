using Microsoft.AspNetCore.Mvc;
using ResERP.Data;
using ResERP.Models;
using ResERP.Models.ViewModels;

namespace ResERP.Controllers
{
    public class EmployeeController : Controller
    {
        //Db Context
        private readonly AppDbContext _context;

        //logger
        private readonly ILogger<BranchController> _logger;

        public EmployeeController(AppDbContext context, ILogger<BranchController> logger)
        {
            _context = context;
            _logger = logger;
        }

        //Main View
        public IActionResult Index()
        {
            return View();
        }

        //Add New Employee View
        public IActionResult AddEmployee()
        {
            //Store List
            var stores = _context.Branches.ToList();
            var storeList = new List<Branch>();

            foreach (var branch in stores)
            {
                var branches = new Branch
                {
                    BranchName = branch.BranchName,
                };

                storeList.Add(branches);
            }

            //Branch Role List
            var roles = _context.BranchRoles.ToList();
            var roleList = new List<BranchRole>();

            foreach(var role in roles)
            {
                var branchRoles = new BranchRole
                {
                    RoleName = role.RoleName
                };

                roleList.Add(branchRoles);
            }

            //ViewData
            ViewData["StoreList"] = storeList;
            ViewData["RoleList"] = roleList;

            return View();
        }

        public async Task<IActionResult> AddNewMember(BranchMemberViewModel model)
        {
            //Mdoel State
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogError($"ModelState Error: {error.ErrorMessage}");
                }
                return View("AddEmployee", model);
            }

            var branchID = _context.Branches.FirstOrDefault(b => b.BranchName == model.BranchName);

            //Branch Member
            var branchMember = new BranchMember
            {
                FullName = model.FullName,
                DateBirth = model.DateBirth,
                PhoneNumber = model.PhoneNumber,
                BranchID = branchID.BranchID
            };

            // Save BranchMember
            try
            {
                await _context.BranchMembers.AddAsync(branchMember);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Branch Member Eorr: {ex.ToString()}");
                return View("AddEmployee", model);
            }

            //Member Address
            var memberAddress = new MemberAddress
            {
                StreetNumber = model.StreetNumber,
                StreetAddress = model.StreetAddress,
                City = model.City,
                Province = model.Province,
                PostalCode = model.PostalCode,
                Country = model.Country,
                MemberID = branchMember.MemberID,
            };

            try
            {
                await _context.MemberAddresses.AddAsync(memberAddress);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Member Address Error: {ex.ToString()}");
                return View("AddEmployee", model);
            }

            //Member Role
            var roles = _context.BranchRoles.FirstOrDefault(br => br.RoleName == model.RoleName);

            var memberRole = new MemberRole
            {
                MemberID = branchMember.MemberID,
                RoleID = roles.RoleID
            };

            try
            {
                _context.MemberRoles.Add(memberRole);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Member Role Error: {ex.ToString()}");
                return View("AddEmployee", model);
            }
        }

    }
}
