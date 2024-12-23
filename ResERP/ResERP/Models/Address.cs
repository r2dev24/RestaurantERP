using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResERP.Models
{
    public class Address
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

        [ForeignKey("Personal")]
        public int PersonalID { get; set; }
    }
}
