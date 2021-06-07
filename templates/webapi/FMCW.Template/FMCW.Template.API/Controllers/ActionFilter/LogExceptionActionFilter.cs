using FMCW.Template.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace FMCW.Template.API.Controllers.ActionFilter
{
    public class LogExceptionActionFilter : IExceptionFilter
    {
        private readonly ILogger<LogExceptionActionFilter> _logger;

        public LogExceptionActionFilter(ILogger<LogExceptionActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var result = BoolResult.Error(context.Exception);
            context.Result = new JsonResult(result)
            {   
                StatusCode = StatusCodes.Status500InternalServerError
            };

            var mensaje = @$"Ha habido una exception no controlado.
                {context.Exception}
                {context.HttpContext.Request.Method} {context.HttpContext.Request.QueryString}
                {context.HttpContext.Request.Headers.Aggregate("headers: ", (s, ns) => s + ns.Key + ": " + ns.Value + " - ")}
                ";
            _logger.LogCritical(mensaje);
        }
    }
}
