using FMCW.Template.API.Controllers.Attributes;
using FMCW.Template.Results;
using Microsoft.AspNetCore.Mvc;

namespace FMCW.Template.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        public int IdUsuario { get; set; }
        public string Jwt { get; set; }
        public int? ResponseStatusCode { get; set; } = null;

        [HttpGet]
        [NoTokenCheck]
        public BoolResult Get()
        {
            var result = BoolResult.Ok();
            ResponseStatusCode = 400;
            return result;
        }
        
    }
}
