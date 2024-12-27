using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResERP.Models.ViewModels
{
    public class BranchMemberViewModel
    {
        [Required]
        public int MemberID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime DateBirth { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string BranchName { get; set; }


        [Required]
        public string RoleName { get; set; }


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
    }
}
