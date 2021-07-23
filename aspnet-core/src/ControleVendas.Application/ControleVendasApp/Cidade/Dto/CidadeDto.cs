using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ControleVendas.ControleVendasApp.Estado.Dto;
using ControleVendas.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleVendas.ControleVendasApp.Cidade.Dto
{
    [AutoMap(typeof(Entities.Cidade))]
    public class CidadeDto : AuditedEntityDto<Guid>
    {
        public CidadeDto()
        {
        }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public EstadoDto Estado { get; set; }

        [Required]
        public Guid? EstadoId { get; set; }
    }
}
