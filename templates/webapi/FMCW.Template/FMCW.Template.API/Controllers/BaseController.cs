using Microsoft.AspNetCore.Mvc;

namespace FMCW.Template.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        public int IdUsuario { get; set; }
        public string Jwt { get; set; }
    }
}
