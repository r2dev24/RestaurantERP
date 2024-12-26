using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResERP.Models
{
    public class BranchAddress
    {
        [Key]
        public int AddressID { get; set; }

        [Required]
        public string Unit { get; set; }

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

        [ForeignKey("Branch")]
        public int BranchID { get; set; }

        public Branch Branch { get; set; }
    }
}
