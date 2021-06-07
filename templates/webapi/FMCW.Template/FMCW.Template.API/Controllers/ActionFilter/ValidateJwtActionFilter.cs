using System;
using System.Linq;
using FMCW.Template.API.Controllers.Attributes;
using FMCW.Template.Results;
using FMCW.Template.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace FMCW.Template.API.Controllers.ActionFilter
{
    public class ValidateJwtActionFilter : Attribute, IActionFilter
    {
        private readonly IJwtManager _jwtManager;

        public ValidateJwtActionFilter(IJwtManager jwtManager)
        {
            _jwtManager = jwtManager;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            IBaseErrorResult result = BoolResult.Ok();

            if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                var actionAttributes = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true).ToList();

                if (actionAttributes.Any(a => a is NoTokenCheckAttribute))
                {
                    return;
                }

                if (context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorizationToken))
                {
                    if (!authorizationToken.ToString().Contains("Bearer"))
                    {
                        result = StringResult.Error("Authorization header must be 'Bearer xxxxxxxx'");
                        context.Result = new JsonResult(result)
                        {
                            StatusCode = StatusCodes.Status401Unauthorized
                        };
                        return;
                    }

                    var jwt = authorizationToken.ToString().Replace("Bearer ", "");
                    result = _jwtManager.ValidateToken(jwt);
                    if (result.Success)
                    {
                        var controller = context.Controller as BaseController;
                        controller.Jwt = jwt;
                        controller.IdUsuario = ((IntResult)result).ResultOk;
                    }
                    else
                    {
                        context.Result = new JsonResult(result)
                        {
                            StatusCode = StatusCodes.Status401Unauthorized
                        };
                        return;
                    }
                }
                else
                {
                    result = StringResult.Error("Authorization header is missing");
                    context.Result = new JsonResult(result)
                    {
                        StatusCode = StatusCodes.Status401Unauthorized
                    };
                    return;
                }
            }
        }
    }
}
