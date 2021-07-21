using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ControleVendas.Authorization.Roles;
using ControleVendas.Authorization.Users;
using ControleVendas.MultiTenancy;
using ControleVendas.Entities;

namespace ControleVendas.EntityFrameworkCore
{
    public class ControleVendasDbContext : AbpZeroDbContext<Tenant, Role, User, ControleVendasDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Fabricante> Fabricante { get; set; }
        public DbSet<Unidade> Unidade { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<ItemVenda> ItemVenda { get; set; }

        public ControleVendasDbContext(DbContextOptions<ControleVendasDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }


    }
}
