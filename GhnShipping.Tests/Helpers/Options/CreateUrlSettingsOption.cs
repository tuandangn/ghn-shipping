using GhnShipping.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Moq;

namespace GhnShipping.Tests.Helpers.Options
{
    public static partial class CreateOption
    {
        public static UrlSettingsBuilder ForUrlSettings()
        {
            return new UrlSettingsBuilder();
        }

        public sealed class UrlSettingsBuilder
        {
            private readonly Mock<IOptionsSnapshot<UrlSettings>> _optionAccessorMock;
            private string _provinceUrl;

            public UrlSettingsBuilder()
            {
                _optionAccessorMock = new Mock<IOptionsSnapshot<UrlSettings>>();
            }

            public UrlSettingsBuilder ProvinceUrl(string url)
            {
                _provinceUrl = url;
                return this;
            }

            public Mock<IOptionsSnapshot<UrlSettings>> Build()
            {
                var urlSettings = new UrlSettings { Province = _provinceUrl};
                _optionAccessorMock.Setup(api => api.Value)
                    .Returns(urlSettings)
                    .Verifiable();

                return _optionAccessorMock;
            }
        }
    }
}
