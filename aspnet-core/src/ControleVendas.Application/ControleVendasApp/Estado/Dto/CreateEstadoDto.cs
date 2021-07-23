using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleVendas.ControleVendasApp.Estado.Dto
{
    [AutoMap(typeof(Entities.Estado))]
    public class CreateEstadoDto
    {
        [Required]
        [StringLength(2)]
        public string Sigla { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}
