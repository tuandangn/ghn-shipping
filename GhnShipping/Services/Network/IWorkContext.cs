namespace GhnShipping.Services.Network
{
    public interface IWorkContext
    {
        public string GetToken();

        public bool IsUseSandbox();
    }
}
