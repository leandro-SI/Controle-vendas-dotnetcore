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

            Dictionary<string, string> dictEstados = new Dictionary<string, string>();

            dictEstados.Add("AC", "Acre");
            dictEstados.Add("AL", "Alagoas");
            dictEstados.Add("AP", "Amapá");
            dictEstados.Add("AM", "Amazonas");
            dictEstados.Add("BA", "Bahia");
            dictEstados.Add("CE", "Ceará");
            dictEstados.Add("ES", "Espírito Santo");
            dictEstados.Add("GO", "Goiás");
            dictEstados.Add("MA", "Maranhão");
            dictEstados.Add("MT", "Mato Grosso");
            dictEstados.Add("MS", "Mato Grosso do Sul");
            dictEstados.Add("MG", "Minas Gerais");
            dictEstados.Add("PA", "Pará");
            dictEstados.Add("PB", "Paraíba");
            dictEstados.Add("PR", "Paraná");
            dictEstados.Add("PE", "Pernambuco");
            dictEstados.Add("PI", "Piauí");
            dictEstados.Add("RJ", "Rio de Janeiro");
            dictEstados.Add("RN", "Rio Grande do Norte");
            dictEstados.Add("RS", "Rio Grande do Sul");
            dictEstados.Add("RO", "Rondônia");
            dictEstados.Add("RR", "Roraima");
            dictEstados.Add("SC", "Santa Catarina");
            dictEstados.Add("SP", "São Paulo");
            dictEstados.Add("SE", "Sergipe");
            dictEstados.Add("TO", "Tocantins");
            dictEstados.Add("DF", "Distrito Federal");

            foreach (var est in dictEstados)
            {
                var defaultEstado = _context.Estado.FirstOrDefault(t => t.Nome == est.Value);

                if (defaultEstado == null)
                {
                    var estado = new Entities.Estado();

                    estado.Nome = est.Value;
                    estado.Sigla = est.Key;

                    _context.Estado.Add(estado);

                }
            }

            _context.SaveChanges();

        }
    }
}
