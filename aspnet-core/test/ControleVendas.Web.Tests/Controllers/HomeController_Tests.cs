using System.Threading.Tasks;
using ControleVendas.Models.TokenAuth;
using ControleVendas.Web.Controllers;
using Shouldly;
using Xunit;

namespace ControleVendas.Web.Tests.Controllers
{
    public class HomeController_Tests: ControleVendasWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}