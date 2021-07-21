using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleVendas.Entities
{
    public class Fabricante : AuditedEntity<Guid>
    {
        public Fabricante()
        {
        }

        public Fabricante(string nome, string site)
        {
            Nome = nome;
            Site = site;
        }

        [Required]
        [StringLength(50)]
        public string Nome{ get; set; }

        [Required]
        [StringLength(100)]
        public string Site { get; set; }

        public void Atualizar(string nome, string site)
        {
            Nome = nome;
            Site = site;
        }
    }
}
