using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResERP.Models
{
    public class BranchMember
    {
        [Key]
        public int MemberID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime DateBirth { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [ForeignKey("Branch")]
        public int BranchID { get; set; }

        public Branch Branch { get; set; }
    }
}
