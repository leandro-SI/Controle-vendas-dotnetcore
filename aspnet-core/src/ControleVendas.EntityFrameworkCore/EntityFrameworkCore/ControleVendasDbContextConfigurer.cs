using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ControleVendas.EntityFrameworkCore
{
    public static class ControleVendasDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ControleVendasDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ControleVendasDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
