using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleVendas.Entities
{
    public class Unidade : AuditedEntity<Guid>
    {
        public Unidade()
        {
        }

        public Unidade(string sigla, string nome)
        {
            Sigla = sigla;
            Nome = nome;
        }

        [Required]
        [StringLength(20)]
        public string Sigla { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public void Atualizar(string sigla, string nome)
        {
            Sigla = sigla;
            Nome = nome;
        }
    }
}
