using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ControleVendas.Entities
{
    public class Produto : AuditedEntity<Guid>
    {
        public Produto()
        {
        }

        public Produto(string descricao, 
            decimal estoque, 
            decimal precoCusto, 
            decimal precoVenda, 
            Guid? fabricanteId, 
            Guid? unidadeId, 
            Guid? tipoId)
        {
            Descricao = descricao;
            Estoque = estoque;
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
            FabricanteId = fabricanteId;
            UnidadeId = unidadeId;
            TipoId = tipoId;
        }

        [StringLength(150)]
        public string Descricao { get; set; }

        [Required]
        public decimal Estoque { get; set; }

        [Required]
        public decimal PrecoCusto { get; set; }

        [Required]
        public decimal PrecoVenda { get; set; }

        [ForeignKey(nameof(FabricanteId))]
        public Fabricante Fabricante { get; set; }

        [Required]
        public Guid? FabricanteId { get; set; }

        [ForeignKey(nameof(UnidadeId))]
        public Unidade Unidade { get; set; }

        [Required]
        public Guid? UnidadeId { get; set; }

        [ForeignKey(nameof(TipoId))]
        public Tipo Tipo { get; set; }

        [Required]
        public Guid? TipoId { get; set; }

        public void Atualizar(
            string descricao, 
            decimal estoque, 
            decimal precoCusto,
            decimal precoVenda,
            Guid? fabricanteId,
            Guid? unidadeId,
            Guid? tipoId
            )
        {
            Descricao = descricao;
            Estoque = estoque;
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
            FabricanteId = fabricanteId;
            UnidadeId = unidadeId;
            TipoId = tipoId;
        }
    }
}
