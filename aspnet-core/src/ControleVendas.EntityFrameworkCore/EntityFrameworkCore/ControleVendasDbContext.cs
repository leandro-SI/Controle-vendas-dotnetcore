using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ControleVendas.Authorization.Roles;
using ControleVendas.Authorization.Users;
using ControleVendas.MultiTenancy;

namespace ControleVendas.EntityFrameworkCore
{
    public class ControleVendasDbContext : AbpZeroDbContext<Tenant, Role, User, ControleVendasDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ControleVendasDbContext(DbContextOptions<ControleVendasDbContext> options)
            : base(options)
        {
        }
    }
}
