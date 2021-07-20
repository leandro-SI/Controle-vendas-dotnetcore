using System.Threading.Tasks;
using Abp.Application.Services;
using ControleVendas.Sessions.Dto;

namespace ControleVendas.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
