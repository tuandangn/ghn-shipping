using GhnShipping.Services.Network;
using GhnShipping.Tests.Helpers.Options;
using Xunit;

namespace GhnShipping.Tests.Services.Network
{
    public class WorkContextTests
    {
        [Fact]
        public void GetToken()
        {
            var apiSettingsAccesssorMock = CreateOption.ForApiSettings().SetToken("_token").Build();
            var workContext = new WorkContext(apiSettingsAccesssorMock.Object);

            var token = workContext.GetToken();

            Assert.Equal("_token", token);
            apiSettingsAccesssorMock.Verify();
        }

        [Fact]
        public void IsUseSandbox()
        {
            var apiSettingsAccessorMock = CreateOption.ForApiSettings().UseSandbox(false).Build();
            var workContext = new WorkContext(apiSettingsAccessorMock.Object);

            var useSandbox = workContext.IsUseSandbox();

            Assert.False(useSandbox);
        }
    }
}
