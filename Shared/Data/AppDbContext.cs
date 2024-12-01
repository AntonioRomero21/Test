/*
 *  Creating Database commands:
 *  add-migration "user account with policies"
 *      This creates a migration file into Migrations folder (undo with: remove-migration)
 *  update-database
 *      This aplies the recent changes of the AppDbContext to the Database
 */
using Microsoft.EntityFrameworkCore;
using HysonMaintainXOrders.Shared.Entities;

namespace HysonMaintainXOrders.Shared.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            UserAccount[] userAccounts = new UserAccount[]
            {
                new UserAccount{ Id = 1, Number = "CARDNO1", FirstName = "super", LastName = "", Email = "super", Password = "super" },
                new UserAccount{ Id = 2, Number = "CARDNO2", FirstName = "leader", LastName = "", Email = "leader", Password = "leader" },
                new UserAccount{ Id = 3, Number = "CARDNO3", FirstName = "tech", LastName = "", Email = "tech", Password = "tech" },
                new UserAccount{ Id = 4, Number = "CARDNO4", FirstName = "clasev", LastName = "", Email = "clasev", Password = "clasev" },
                new UserAccount{ Id = 5, Number = "HY1USR1", FirstName = "User", LastName = "User", Email = "user@rainbird.com", Password = "user" },
                new UserAccount{ Id = 6, Number = "CST1DMR7", FirstName = "Diego", LastName = "Mendivil Rodríguez", Email = "droid@rainbird.com", Password = "droid" },
                new UserAccount{ Id = 7, Number = "CST1LDR0", FirstName = "Lorenzo", LastName = "Díaz Ramirez", Email = "lorenzo@rainbird.com", Password = "lorenzo" },
            };
            modelBuilder.Entity<UserAccount>().HasData(userAccounts);

            UserAccountRoles[] userAccountRoles = new UserAccountRoles[]
            {
                new UserAccountRoles{ Id = 1, UserAccountId = 1, RoleName = UserRoles.SUPERVISOR.ToString() },
                new UserAccountRoles{ Id = 2, UserAccountId = 2, RoleName = UserRoles.LEADER.ToString()},
                new UserAccountRoles{ Id = 3, UserAccountId = 3, RoleName = UserRoles.TECHNICIAN.ToString()},
                new UserAccountRoles{ Id = 4, UserAccountId = 4, RoleName = UserRoles.CLASE_V.ToString()},
                new UserAccountRoles{ Id = 5, UserAccountId = 5, RoleName = UserRoles.SUPERVISOR.ToString()},
                new UserAccountRoles{ Id = 6, UserAccountId = 6, RoleName = UserRoles.SUPERVISOR.ToString()},
                new UserAccountRoles{ Id = 7, UserAccountId = 7, RoleName = UserRoles.SUPERVISOR.ToString()},
            };
            modelBuilder.Entity<UserAccountRoles>().HasData(userAccountRoles);
        }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserAccountRoles> UserAccountRoles { get; set; }
    }

}
