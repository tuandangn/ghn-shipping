using GhnShipping.Services.Network;
using Moq;

namespace GhnShipping.Tests.Helpers
{
    public static class CreateWorkContext
    {
        public static IWorkContext Default => Mock.Of<IWorkContext>();

        public static WorkContextBuilder WithToken(string token)
        {
            var builder = new WorkContextBuilder();
            return builder.WithToken(token);
        }

        public sealed class WorkContextBuilder
        {
            private readonly Mock<IWorkContext> _workContextMock;

            public WorkContextBuilder()
            {
                _workContextMock = new Mock<IWorkContext>();
            }

            public WorkContextBuilder WithToken(string token)
            {
                _workContextMock.Setup(workContext => workContext.GetToken())
                    .Returns(token)
                    .Verifiable();

                return this;
            }

            public WorkContextBuilder UseSandbox(bool useSandbox)
            {
                _workContextMock.Setup(workContext => workContext.IsUseSandbox())
                    .Returns(useSandbox)
                    .Verifiable();

                return this;
            }

            public Mock<IWorkContext> Build()
            {
                return _workContextMock;
            }
        }
    }
}
