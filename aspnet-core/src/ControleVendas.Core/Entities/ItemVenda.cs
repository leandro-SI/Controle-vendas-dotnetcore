using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ControleVendas.Entities
{
    public class ItemVenda : AuditedEntity<Guid>
    {
        public ItemVenda()
        {
        }

        public ItemVenda(Guid? produtoId, Guid? vendaId, decimal quantidade, decimal preco)
        {
            ProdutoId = produtoId;
            VendaId = vendaId;
            Quantidade = quantidade;
            Preco = preco;
        }

        [ForeignKey(nameof(ProdutoId))]
        public Produto Produto { get; set; }

        [Required]
        public Guid? ProdutoId { get; set; }

        [ForeignKey(nameof(VendaId))]
        public Venda Venda { get; set; }

        [Required]
        public Guid? VendaId { get; set; }

        public decimal Quantidade { get; set; }

        public decimal Preco { get; set; }


    }
}
