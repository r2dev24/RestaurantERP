using Microsoft.AspNetCore.Mvc;
using ResERP.Data;
using ResERP.Models;
using ResERP.Models.Payroll;
using ResERP.Models.ViewModels;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PayrollSubmit(PayrollViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Payroll", model);
            }

            try
            {
                // Deduction 추가
                var deduction = new Deduction
                {
                    FederalTax = model.FederalTax,
                    ProvincialTax = model.ProvincialTax,
                    CPP = model.CPP,
                    EmployeeInsurance = model.EmployeeInsurance,
                };

                await _context.Deductions.AddAsync(deduction);
                await _context.SaveChangesAsync();

                // Payroll 추가
                var payroll = new Payroll
                {
                    BaseSalary = model.BaseSalary,
                    WorkHours = model.WorkHours,
                    OverTimeWorkHours = model.OverTimeWorkHours,
                    PromotionPay = model.PromotionPay,
                    PayDate = model.PayDate,
                    MemberID = model.MemberID,
                    DeductionID = deduction.DeductionID
                };

                await _context.Payrolls.AddAsync(payroll);
                await _context.SaveChangesAsync();

                // PayType 추가
                var paytype = new PayType
                {
                    PayTypes = model.PayTypes,
                    Payroll_ID = payroll.Payroll_ID,
                };

                await _context.PayTypes.AddAsync(paytype);
                await _context.SaveChangesAsync();

                return RedirectToAction("EmployeeList", "Employee");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
                return View("Payroll", model);
            }
        }



    }
}
