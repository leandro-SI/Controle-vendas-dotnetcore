using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ControleVendas.Entities
{
    public class PessoaGrupo : AuditedEntity<Guid>
    {
        public PessoaGrupo()
        {
        }

        public PessoaGrupo(Guid? pessoaId, Guid? grupoId)
        {
            PessoaId = pessoaId;
            GrupoId = grupoId;
        }

        [ForeignKey(nameof(PessoaId))]
        public Pessoa Pessoa { get; set; }

        [Required]
        public Guid? PessoaId { get; set; }

        [ForeignKey(nameof(GrupoId))]
        public Grupo Grupo { get; set; }
        [Required]
        public Guid? GrupoId { get; set; }
    }
}
