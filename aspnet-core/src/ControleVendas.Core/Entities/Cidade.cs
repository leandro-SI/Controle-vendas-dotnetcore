using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ControleVendas.Entities
{

    [AutoMapTo(typeof(Cidade))]
    public class Cidade : AuditedEntity<Guid>
    {
        public Cidade()
        {
        }

        public Cidade(string nome, Estado estado, Guid estadoId)
        {
            Nome = nome;
            Estado = estado;
            EstadoId = estadoId;
        }

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
