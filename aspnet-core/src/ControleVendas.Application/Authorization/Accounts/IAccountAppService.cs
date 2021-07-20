using System.Threading.Tasks;
using Abp.Application.Services;
using ControleVendas.Authorization.Accounts.Dto;

namespace ControleVendas.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
