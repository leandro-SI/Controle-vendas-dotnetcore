using Abp.Application.Services;
using ControleVendas.ControleVendasApp.Estado.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleVendas.ControleVendasApp.Estado
{
    public interface IEstadoAppService : IAsyncCrudAppService<EstadoDto, Guid, PagedEstadoResultRequestDto, CreateEstadoDto, EstadoDto>
    {
    }
}
