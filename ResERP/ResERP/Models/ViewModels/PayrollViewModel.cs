using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResERP.Models.ViewModels
{
    public class PayrollViewModel
    {
        [Required]
        public int MemberID { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal BaseSalary { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal WorkHours { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? OverTimeWorkHours { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? PromotionPay { get; set; }

        public DateTime PayDate { get; set; }

        [Required]
        public string PayTypes { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal FederalTax { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal ProvincialTax { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal CPP { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal EmployeeInsurance { get; set; }
    }
}
