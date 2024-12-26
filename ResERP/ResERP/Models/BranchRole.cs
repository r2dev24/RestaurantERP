using System.ComponentModel.DataAnnotations;

namespace ResERP.Models
{
    public class BranchRole
    {
        [Key]
        public int RoleID { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
