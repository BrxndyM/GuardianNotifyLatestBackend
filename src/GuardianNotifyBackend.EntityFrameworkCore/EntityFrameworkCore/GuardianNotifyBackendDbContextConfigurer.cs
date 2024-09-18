using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace GuardianNotifyBackend.EntityFrameworkCore
{
    public static class GuardianNotifyBackendDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<GuardianNotifyBackendDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<GuardianNotifyBackendDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
