using GhnShipping.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Moq;

namespace GhnShipping.Tests.Helpers.Options
{
    public static partial class CreateOption
    {
        public static ApiSettingsBuilder ForApiSettings()
        {
            return new ApiSettingsBuilder();
        }

        public sealed class ApiSettingsBuilder
        {
            private readonly Mock<IOptionsSnapshot<ApiSettings>> _optionAccessorMock;
            private string _token;
            private bool _useSandbox;

            public ApiSettingsBuilder()
            {
                _optionAccessorMock = new Mock<IOptionsSnapshot<ApiSettings>>();
            }

            public ApiSettingsBuilder SetToken(string token)
            {
                _token = token;
                return this;
            }

            public ApiSettingsBuilder UseSandbox(bool useSandbox)
            {
                _useSandbox = useSandbox;
                return this;
            }

            public Mock<IOptionsSnapshot<ApiSettings>> Build()
            {
                var apiSettings = new ApiSettings { Token = _token, UseSanbox = _useSandbox };
                _optionAccessorMock.Setup(api => api.Value)
                    .Returns(apiSettings)
                    .Verifiable();

                return _optionAccessorMock;
            }
        }
    }
}
