using Microsoft.AspNetCore.Mvc;

namespace GhnShipping.Controllers
{
    [Route("directory")]
    public class DirectoryController : BaseController
    {
        public int[] Get()
        {
            return new[] { 1, 2, 3 };
        }
    }
}
