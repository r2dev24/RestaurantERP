using Microsoft.EntityFrameworkCore;
using ResERP.Models;

namespace ResERP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Header Office DB
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Address> Address { get; set; }

        //Branch DB
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchAddress> BranchAdress { get; set; }
        public DbSet<BranchMember> BranchMembers { get; set; }
        public DbSet<MemberAddress> MemberAddresses { get; set; }
        public DbSet<BranchRole> BranchRoles { get; set; }
        public DbSet<MemberRole> MemberRoles { get; set; }
    }
}
