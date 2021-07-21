using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ControleVendas.Entities
{
    public class Pessoa : AuditedEntity<Guid>
    {
        public Pessoa()
        {
        }

        public Pessoa(string nome, string endereco, string bairro, string telefone, string email, Guid? cidadeId)
        {
            Nome = nome;
            Endereco = endereco;
            Bairro = bairro;
            Telefone = telefone;
            Email = email;
            CidadeId = cidadeId;
        }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Endereco { get; set; }

        [StringLength(100)]
        public string Bairro { get; set; }

        [StringLength(15)]
        public string Telefone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [ForeignKey(nameof(CidadeId))]
        public Cidade Cidade { get; set; }

        public Guid? CidadeId { get; set; }


        public void Atualizar(string nome, 
            string endereco, 
            string bairro, 
            string telefone,
            string email,
            Guid? cidadeId
            )
        {
            Nome = nome;
            Endereco = endereco;
            Bairro = bairro;
            Telefone = telefone;
            Email = email;
            CidadeId = cidadeId;
        }
    }
}
