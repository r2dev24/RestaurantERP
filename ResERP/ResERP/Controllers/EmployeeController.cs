using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResERP.Data;
using ResERP.Models;
using ResERP.Models.Payroll;
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

        [HttpPost]
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

                return RedirectToAction("EmployeeList");
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Member Role Error: {ex.ToString()}");
                return View("AddEmployee", model);
            }
        }

        //Employee List View
        [HttpGet]
        public async Task<IActionResult> EmployeeList(int page = 1, int pageSize = 10)
        {
            var members = await _context.BranchMembers.ToListAsync();
            var memberRoles = await _context.MemberRoles.ToListAsync();
            var addresses = await _context.MemberAddresses.ToListAsync();
            var roles = await _context.BranchRoles.ToListAsync();
            var branches = await _context.Branches.ToListAsync();

            var list = new List<BranchMemberViewModel>();

            foreach (var m in members)
            {
                var memberAddress = addresses.FirstOrDefault(a => a.MemberID == m.MemberID);
                var memberRole = memberRoles.Where(mr => mr.MemberID == m.MemberID);
                var memberBranch = branches.FirstOrDefault(b => b.BranchID == m.BranchID);

                foreach (var mr in memberRole)
                {
                    var role = roles.FirstOrDefault(r => r.RoleID == mr.RoleID);

                    if (role != null)
                    {
                        list.Add(new BranchMemberViewModel
                        {
                            MemberID = m.MemberID,
                            FullName = m.FullName,
                            DateBirth = m.DateBirth,
                            PhoneNumber = m.PhoneNumber,
                            RoleName = role.RoleName,
                            BranchName = memberBranch?.BranchName ?? "Unknown",
                            StreetNumber = memberAddress?.StreetNumber ?? "N/A",
                            StreetAddress = memberAddress?.StreetAddress ?? "N/A",
                            City = memberAddress?.City ?? "N/A",
                            Province = memberAddress?.Province ?? "N/A",
                            Country = memberAddress?.Country ?? "N/A",
                            PostalCode = memberAddress?.PostalCode ?? "N/A",
                        });
                    }
                }
            }

            int totalCount = list.Count;

            var paginatedList = list
                .Skip((page - 1) * pageSize) 
                .Take(pageSize)   
                .ToList();

            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;

            return View(paginatedList);
        }

        //Get Employee Detail
        [HttpGet]
        public async Task<IActionResult> GetEmployeeDetail(int id)
        {
            //Member Branches
            var member = await _context.BranchMembers.FirstOrDefaultAsync(m => m.MemberID == id);
            var address = await _context.MemberAddresses.FirstOrDefaultAsync(a => a.MemberID == id);
            var role = await _context.MemberRoles.FirstOrDefaultAsync(r => r.MemberID == id);
            var getRole = await _context.BranchRoles.FirstOrDefaultAsync(gr => gr.RoleID == role.RoleID);
            var branch = await _context.Branches.FirstOrDefaultAsync(b => b.BranchID == member.BranchID);

            var details = new BranchMemberViewModel
            {
                FullName = member.FullName,
                RoleName = getRole.RoleName,
                DateBirth = member.DateBirth,
                PhoneNumber = member.PhoneNumber,
                StreetNumber = address.StreetNumber,
                StreetAddress = address.StreetAddress,
                City = address.City,
                Province = address.Province,
                PostalCode = address.PostalCode,
                Country = address.Country,
                BranchName = branch.BranchName,
            };

            //Pay roll
            var payroll = await _context.Payrolls.FirstOrDefaultAsync(p => p.MemberID == member.MemberID);

            if (payroll == null)
            {
                payroll = new Payroll
                {
                    BaseSalary = 0,
                    WorkHours = 0,
                    OverTimeWorkHours = 0,
                    PromotionPay = 0,
                    PayDate = DateTime.Now
                };
            }

            var paytype = await _context.PayTypes.FirstOrDefaultAsync(pt => pt.Payroll_ID == payroll.Payroll_ID);

            if (paytype == null)
            {
                paytype = new PayType
                {
                    PayTypes = "Default"
                };
            }

            var deduction = await _context.Deductions.FirstOrDefaultAsync(d => d.DeductionID == payroll.DeductionID);

            if (deduction == null)
            {
                deduction = new Deduction
                {
                    FederalTax = 0,
                    ProvincialTax = 0,
                    CPP = 0,
                    EmployeeInsurance = 0
                };
            }


            var paydetails = new PayrollViewModel
            {
                BaseSalary = payroll.BaseSalary,
                WorkHours = payroll.WorkHours,
                OverTimeWorkHours = payroll.OverTimeWorkHours,
                PromotionPay  = payroll.PromotionPay,
                PayDate = payroll.PayDate,
                PayTypes = paytype.PayTypes,
                FederalTax = deduction.FederalTax,
                ProvincialTax = deduction.ProvincialTax,
                CPP = deduction.CPP,
                EmployeeInsurance = deduction.EmployeeInsurance,
            };

            ViewData["PayDetail"] = paydetails;

            ViewData["PayDetail"] = new PayrollViewModel
            {
                BaseSalary = payroll.BaseSalary,
                WorkHours = payroll.WorkHours,
                OverTimeWorkHours = payroll.OverTimeWorkHours,
                PromotionPay = payroll.PromotionPay,
                PayDate = payroll.PayDate,
                PayTypes = paytype.PayTypes,
                FederalTax = deduction.FederalTax,
                ProvincialTax = deduction.ProvincialTax,
                CPP = deduction.CPP,
                EmployeeInsurance = deduction.EmployeeInsurance,
            };

            return PartialView("_EmpDetail", details);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.BranchMembers.FirstOrDefaultAsync(m => m.MemberID == id);

            if (employee == null)
            {
                Console.WriteLine("Cannot find employee information");
                return RedirectToAction("Index "); // Redirect to list if not found
            }

            try
            {
                _context.BranchMembers.Remove(employee);
                await _context.SaveChangesAsync();

                return RedirectToAction("EmployeeList"); // Redirect to EmployeeList after deletion
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return View("Error"); // Redirect to an error page
            }
        }


    }
}
