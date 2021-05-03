using System;
using System.Net;
using System.Threading.Tasks;
using KnowYourStuffCore.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KnowYourStuffWebApi.ExceptionHandlers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Delegate)]
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var statusCode = context.Exception switch
            {
                NotFoundException => HttpStatusCode.NotFound,
                MissingPropertyException => HttpStatusCode.BadRequest,
                DuplicatedPlatformException => HttpStatusCode.Conflict,
                _ => HttpStatusCode.InternalServerError
            };

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.Result = new JsonResult(new
            {
                error = context.Exception.Message
            });

            context.ExceptionHandled = true;
        }
    }
}