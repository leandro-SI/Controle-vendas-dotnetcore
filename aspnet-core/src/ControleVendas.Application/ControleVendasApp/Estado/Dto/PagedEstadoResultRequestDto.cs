using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVendas.ControleVendasApp.Estado.Dto
{
    public class PagedEstadoResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; } // palavra para pesquisa
    }
}
