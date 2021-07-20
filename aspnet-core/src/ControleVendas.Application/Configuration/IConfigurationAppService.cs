using System.Threading.Tasks;
using ControleVendas.Configuration.Dto;

namespace ControleVendas.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
