using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using GuardianNotifyBackend.Authorization.Roles;
using GuardianNotifyBackend.Authorization.Users;
using GuardianNotifyBackend.MultiTenancy;
using GuardianNotifyBackend.Domain;

namespace GuardianNotifyBackend.EntityFrameworkCore
{
    public class GuardianNotifyBackendDbContext : AbpZeroDbContext<Tenant, Role, User, GuardianNotifyBackendDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Person> Persons { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<CloseContact> CloseContacts { get; set; }

        public GuardianNotifyBackendDbContext(DbContextOptions<GuardianNotifyBackendDbContext> options)
            : base(options)
        {
        }
    }
}
