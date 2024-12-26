using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResERP.Models
{
    public class Branch
    {
        [Key]
        public int BranchID { get; set; }

        [Required]
        public string BranchName { get; set; }

        [ForeignKey("Account")]
        public int AccountID { get; set; }

        public Account Account { get; set; }
    }
}
