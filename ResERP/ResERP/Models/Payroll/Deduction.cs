using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResERP.Models.Payroll
{
    public class Deduction
    {
        [Key]
        public int DeductionID { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal FederalTax { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal ProvincialTax { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal CPP {  get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal EmployeeInsurance { get; set; }
    }
}
