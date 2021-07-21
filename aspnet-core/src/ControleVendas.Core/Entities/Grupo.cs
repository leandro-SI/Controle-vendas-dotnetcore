using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleVendas.Entities
{
    public class Grupo : AuditedEntity<Guid>
    {

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public void Atualizar(string nome)
        {
            Nome = nome;
        }
    }
}
