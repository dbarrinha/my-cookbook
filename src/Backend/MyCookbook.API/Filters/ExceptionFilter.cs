using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyCookbook.Communication.Responses;
using MyCookbook.Exceptions;
using MyCookbook.Exceptions.ExceptionsBase;

namespace MyCookbook.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is MyCookbookException)
                HandleProjectException(context);
            else
                ThrowUnknowException(context);
        }

        private void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException exception)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var responseErrorJson = new ResponseErrorJson(exception.ErrorMessages);
                context.Result = new BadRequestObjectResult(responseErrorJson);
            }
        }

        private void ThrowUnknowException(ExceptionContext context)
        {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var responseErrorJson = new ResponseErrorJson(ResourceMessageException.UNKNOW_ERROR);
                context.Result = new ObjectResult(responseErrorJson);
        }
    }
}
