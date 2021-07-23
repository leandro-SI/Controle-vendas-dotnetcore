using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using ControleVendas.Authorization;
using ControleVendas.ControleVendasApp.Cidade.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVendas.ControleVendasApp.Cidade
{
    [AbpAuthorize(PermissionNames.ControleVendas_Cidade)]
    public class CidadeAppService : AsyncCrudAppService<Entities.Cidade, CidadeDto, Guid, PagedCidadeResultRequestDto, CreateCidadeDto, CidadeDto>, ICidadeAppService
    {
        public CidadeAppService(IRepository<Entities.Cidade, Guid> repository) : base(repository)
        {
        }

        [AbpAuthorize(PermissionNames.ControleVendas_ListarCidade)]
        public override async Task<PagedResultDto<CidadeDto>> GetAllAsync(PagedCidadeResultRequestDto input)
        {
            return await base.GetAllAsync(input);
        }

        [AbpAuthorize(PermissionNames.ControleVendas_DetalheCidade)]
        public override async Task<CidadeDto> GetAsync(EntityDto<Guid> input)
        {
            return await base.GetAsync(input);
        }

        [AbpAuthorize(PermissionNames.ControleVendas_CriarCidade)]
        public override async Task<CidadeDto> CreateAsync(CreateCidadeDto input)
        {
            return await base.CreateAsync(input);
        }

        [AbpAuthorize(PermissionNames.ControleVendas_AlterarCidade)]
        public override async Task<CidadeDto> UpdateAsync(CidadeDto input)
        {
            return await base.UpdateAsync(input);
        }

        [AbpAuthorize(PermissionNames.ControleVendas_ExcluirCidade)]
        public override async Task DeleteAsync(EntityDto<Guid> input)
        {
            await base.DeleteAsync(input);
        }

        protected override IQueryable<Entities.Cidade> CreateFilteredQuery(PagedCidadeResultRequestDto input)
        {
            var query = Repository.GetAllIncluding(x => x.Estado);

            if (!input.Keyword.IsNullOrWhiteSpace())
            {
                query = query.Where(x => x.Nome.Contains(input.Keyword) ||
                x.Estado.Nome.Contains(input.Keyword));
            }

            return query = query.OrderByDescending(x => x.Nome);
        }

        protected override void MapToEntity(CidadeDto updateInput, Entities.Cidade entity)
        {
            entity.Atualizar(updateInput.Nome, updateInput.EstadoId);
        }

    }
}
