using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResERP.Models
{
    public class MemberAddress
    {
        [Key]
        public int AddressID { get; set; }

        [Required]
        public string StreetNumber { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        [ForeignKey("BranchMember")]
        public int MemberID { get; set; }
    }
}
