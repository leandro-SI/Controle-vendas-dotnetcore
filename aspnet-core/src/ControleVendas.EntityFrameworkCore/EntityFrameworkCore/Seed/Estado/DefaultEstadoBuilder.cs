using ControleVendas.Editions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleVendas.EntityFrameworkCore.Seed.Estado
{
    public class DefaultEstadoBuilder
    {
        private readonly ControleVendasDbContext _context;

        public DefaultEstadoBuilder(ControleVendasDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultEstados();
        }

        private void CreateDefaultEstados()
        {
            var defaultEstado = _context.Estado.FirstOrDefault(t => t.Nome == "Brasil");

            if (defaultEstado == null)
            {
                defaultEstado = new Entities.Estado();

                defaultEstado.Nome = "Brasil";
                defaultEstado.Sigla = "BR";

                _context.Estado.Add(defaultEstado);
                _context.SaveChanges();
            }
        }
    }
}
