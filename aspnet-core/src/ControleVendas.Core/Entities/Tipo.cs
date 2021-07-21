using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleVendas.Entities
{
    public class Tipo : AuditedEntity<Guid>
    {
        public Tipo()
        {
        }

        public Tipo(string nome)
        {
            Nome = nome;
        }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public void Atualizar(string nome)
        {
            Nome = nome;
        }
    }
}
