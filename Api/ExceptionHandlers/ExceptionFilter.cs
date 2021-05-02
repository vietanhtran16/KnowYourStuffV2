using System;
using System.Net;
using System.Threading.Tasks;
using KnowYourStuffCore.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KnowYourStuffWebApi.ExceptionHandlers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Delegate)]
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;

            if (context.Exception is NotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
            }
            
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.ExceptionHandled = true;
        }
    }
}