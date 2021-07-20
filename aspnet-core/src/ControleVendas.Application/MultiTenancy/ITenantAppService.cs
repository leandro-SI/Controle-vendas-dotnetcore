using Abp.Application.Services;
using ControleVendas.MultiTenancy.Dto;

namespace ControleVendas.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

