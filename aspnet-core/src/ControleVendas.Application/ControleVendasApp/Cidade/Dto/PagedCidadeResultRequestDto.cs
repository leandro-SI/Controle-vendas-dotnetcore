using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVendas.ControleVendasApp.Cidade.Dto
{
    public class PagedCidadeResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; } // palavra para pesquisa
    }
}
