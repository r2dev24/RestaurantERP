using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResERP.Models
{
    public class Personal
    {
        [Key]
        public int PersonalID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime DateBirth { get; set; }

        [ForeignKey("Account")]
        public int AccountID { get; set; }
    }
}
