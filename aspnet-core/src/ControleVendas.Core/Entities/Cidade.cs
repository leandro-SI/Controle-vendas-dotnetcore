using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ControleVendas.Entities
{
    public class Cidade : AuditedEntity<Guid>
    {
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [ForeignKey(nameof(EstadoId))]
        public Estado Estado { get; set; }

        [Required]
        public Guid? EstadoId { get; set; }

        public void Atualizar(string nome, Guid? estadoId)
        {
            Nome = nome;
            EstadoId = estadoId;
        }

    }
}
