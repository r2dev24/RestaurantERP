using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResERP.Models
{
    public class MemberRole
    {
        [Key]
        public int MemberRoleID { get; set; }

        [ForeignKey("BranchMember")]
        public int MemberID { get; set; }

        [ForeignKey("BranchRole")]
        public int RoleID { get; set; }

        public BranchMember BranchMember { get; set; }
        public BranchRole BranchRole { get; set; }
    }
}
