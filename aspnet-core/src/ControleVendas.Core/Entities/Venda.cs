using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ControleVendas.Entities
{
    public class Venda : AuditedEntity<Guid>
    {
        public Venda()
        {
        }

        public Venda(Guid? pessoaId, 
            DateTime? dataVenda, 
            decimal valorVenda, 
            decimal desconto, 
            decimal acrescimos, 
            decimal valorFinal, 
            string obs
            )
        {
            PessoaId = pessoaId;
            DataVenda = dataVenda;
            ValorVenda = valorVenda;
            Desconto = desconto;
            Acrescimos = acrescimos;
            ValorFinal = valorFinal;
            Obs = obs;
        }

        [ForeignKey(nameof(PessoaId))]
        public Pessoa Cliente { get; set; }

        [Required]
        public Guid? PessoaId { get; set; }

        public DateTime? DataVenda { get; set; }

        public decimal ValorVenda { get; set; }

        public decimal Desconto { get; set; }

        public decimal Acrescimos { get; set; }

        public decimal ValorFinal { get; set; }

        [StringLength(200)]
        public string Obs { get; set; }


    }
}
