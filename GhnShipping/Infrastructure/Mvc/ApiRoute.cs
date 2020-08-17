using Microsoft.AspNetCore.Mvc;
using static GhnShipping.Infrastructure.Defaults;

namespace GhnShipping.Infrastructure.Mvc
{
    public class PrefixedRoute : RouteAttribute
    {
        public PrefixedRoute(string prefix, string template) : base($"{prefix}/{template}")
        { }
    }

    public class VersionRoute : PrefixedRoute
    {
        public VersionRoute(string prefix, string version, string template) : base($"{prefix}/{version}", template)
        { }
    }

    public sealed class ApiRoute : VersionRoute
    {
        public ApiRoute(string template) : base(Prefix, Version, template)
        { }
    }
}
