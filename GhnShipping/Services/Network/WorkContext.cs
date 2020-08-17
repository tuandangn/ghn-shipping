using GhnShipping.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace GhnShipping.Services.Network
{
    public sealed class WorkContext : IWorkContext
    {
        private readonly IOptionsSnapshot<ApiSettings> _optionsAccessor;

        public WorkContext(IOptionsSnapshot<ApiSettings> optionAccessor)
        {
            _optionsAccessor = optionAccessor;
        }

        public string GetToken()
        {
            var apiSettings = _optionsAccessor.Value;
            var token = apiSettings.Token;

            return token;
        }

        public bool IsUseSandbox()
        {
            var apiSettings = _optionsAccessor.Value;
            var useSandbox = apiSettings.UseSanbox;

            return useSandbox;
        }
    }
}
