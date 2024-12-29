using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResERP.Models.Payroll
{
    public class PayType
    {
        [Key]
        public int PayTypeID { get; set; }

        [Required]
        public string PayTypes {  get; set; }

        [ForeignKey("PayRoll")]
        public int Payroll_ID { get; set; }
    }
}
