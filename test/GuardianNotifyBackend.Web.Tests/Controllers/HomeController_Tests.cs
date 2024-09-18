using System.Threading.Tasks;
using GuardianNotifyBackend.Models.TokenAuth;
using GuardianNotifyBackend.Web.Controllers;
using Shouldly;
using Xunit;

namespace GuardianNotifyBackend.Web.Tests.Controllers
{
    public class HomeController_Tests: GuardianNotifyBackendWebTestBase
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