using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleVendas.ControleVendasApp.Estado.Dto
{
    public class EstadoDto : AuditedEntityDto<Guid>
    {
        public EstadoDto()
        {
        }

        [Required]
        [StringLength(2)]
        public string Sigla { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

    }
}
