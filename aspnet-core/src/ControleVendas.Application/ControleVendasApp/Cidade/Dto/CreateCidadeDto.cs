using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleVendas.ControleVendasApp.Cidade.Dto
{
    [AutoMap(typeof(Entities.Cidade))]
    public class CreateCidadeDto
    {
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        public Guid? EstadoId { get; set; }
    }
}
