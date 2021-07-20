using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ControleVendas.Configuration;
using ControleVendas.Web;

namespace ControleVendas.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ControleVendasDbContextFactory : IDesignTimeDbContextFactory<ControleVendasDbContext>
    {
        public ControleVendasDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ControleVendasDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ControleVendasDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ControleVendasConsts.ConnectionStringName));

            return new ControleVendasDbContext(builder.Options);
        }
    }
}
