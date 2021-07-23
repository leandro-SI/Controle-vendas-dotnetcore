using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using ControleVendas.ControleVendasApp.Estado.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVendas.ControleVendasApp.Estado
{
    class EstadoAppService : AsyncCrudAppService<Entities.Estado, EstadoDto, Guid, PagedEstadoResultRequestDto, CreateEstadoDto, EstadoDto>, IEstadoAppService
    {
        public EstadoAppService(IRepository<Entities.Estado, Guid> repository) : base(repository)
        {
        }

        public override async Task<PagedResultDto<EstadoDto>> GetAllAsync(PagedEstadoResultRequestDto input)
        {
            return await base.GetAllAsync(input);
        }

        public override async Task<EstadoDto> GetAsync(EntityDto<Guid> input)
        {
            return await base.GetAsync(input);
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


    }
}
