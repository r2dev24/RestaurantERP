using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ResERP.Models.Payroll
{
    public class Payroll
    {
        [Key]
        public int Payroll_ID { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal BaseSalary { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal WorkHours { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? OverTimeWorkHours { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? PromotionPay {  get; set; }

        public DateTime PayDate { get; set; }

        [ForeignKey("BranchMember")]
        public int MemberID { get; set; }

        [ForeignKey("Dedeuction")]
        public int DeductionID { get; set; }
    }
}
