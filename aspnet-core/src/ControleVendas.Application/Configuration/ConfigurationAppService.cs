using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ControleVendas.Configuration.Dto;

namespace ControleVendas.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ControleVendasAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
