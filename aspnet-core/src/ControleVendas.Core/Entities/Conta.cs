using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ControleVendas.Entities
{
    public class Conta : AuditedEntity<Guid>
    {
        public Conta()
        {
        }

        public Conta(Guid? pessoaId, DateTime? dataEmissao, DateTime? dataVencimento, decimal valor, string paga)
        {
            PessoaId = pessoaId;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            Valor = valor;
            Paga = paga;
        }

        [ForeignKey(nameof(PessoaId))]
        public Pessoa Cliente { get; set; }

        [Required]
        public Guid? PessoaId { get; set; }

        public DateTime? DataEmissao { get; set; }

        public DateTime? DataVencimento { get; set; }

        public decimal Valor { get; set; }

        [StringLength(1)]
        public string Paga { get; set; }
    }
}
