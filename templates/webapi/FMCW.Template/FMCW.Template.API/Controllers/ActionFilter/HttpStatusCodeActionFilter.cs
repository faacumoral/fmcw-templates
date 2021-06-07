using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FMCW.Template.API.Controllers.ActionFilter
{
    public class HttpStatusCodeActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
            if (context.Controller is BaseController baseController)
            {
                if (baseController.ResponseStatusCode.HasValue)
                {
                    context.HttpContext.Response.StatusCode = baseController.ResponseStatusCode.Value;
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
