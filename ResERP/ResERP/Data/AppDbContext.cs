using Microsoft.EntityFrameworkCore;
using ResERP.Models;

namespace ResERP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
