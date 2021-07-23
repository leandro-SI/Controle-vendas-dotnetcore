using Abp.Application.Services;
using ControleVendas.ControleVendasApp.Cidade.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVendas.ControleVendasApp.Cidade
{
    public interface ICidadeAppService : IAsyncCrudAppService<CidadeDto, Guid, PagedCidadeResultRequestDto, CreateCidadeDto, CidadeDto>
    {
    }
}
