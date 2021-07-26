using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using ControleVendas.Authorization;
using ControleVendas.ControleVendasApp.Estado.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVendas.ControleVendasApp.Estado
{
    [AbpAuthorize(PermissionNames.ControleVendas_Estado)]
    public class EstadoAppService : AsyncCrudAppService<Entities.Estado, EstadoDto, Guid, PagedEstadoResultRequestDto, CreateEstadoDto, EstadoDto>, IEstadoAppService
    {
        public EstadoAppService(IRepository<Entities.Estado, Guid> repository) : base(repository)
        {
        }

        [AbpAuthorize(PermissionNames.ControleVendas_ListarEstado)]
        public override async Task<PagedResultDto<EstadoDto>> GetAllAsync(PagedEstadoResultRequestDto input)
        {
            return await base.GetAllAsync(input);
        }

        [AbpAuthorize(PermissionNames.ControleVendas_DetalheEstado)]
        public override async Task<EstadoDto> GetAsync(EntityDto<Guid> input)
        {
            return await base.GetAsync(input);
        }

        [AbpAuthorize(PermissionNames.ControleVendas_CriarEstado)]
        public override async Task<EstadoDto> CreateAsync(CreateEstadoDto input)
        {
            return await base.CreateAsync(input);
        }

        [AbpAuthorize(PermissionNames.ControleVendas_ExcluirEstado)]
        public override async Task DeleteAsync(EntityDto<Guid> input)
        {
            await base.DeleteAsync(input);
        }

        protected override IQueryable<Entities.Estado> CreateFilteredQuery(PagedEstadoResultRequestDto input)
        {
            var query = Repository.GetAll();

            if (!input.Keyword.IsNullOrWhiteSpace())
            {
                query = query.Where(x => x.Nome.Contains(input.Keyword) ||
                x.Nome.Contains(input.Keyword));
            }

            return query = query.OrderByDescending(x => x.Nome);
        }

        protected override void MapToEntity(EstadoDto updateInput, Entities.Estado entity)
        {
            entity.Atualizar(updateInput.Sigla, updateInput.Nome);
        }

    }
}
