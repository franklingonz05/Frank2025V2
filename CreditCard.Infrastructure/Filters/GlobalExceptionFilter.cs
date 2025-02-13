using CreditCard.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace CreditCard.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BusinessException))
            {
                var exception = (BusinessException)context.Exception;

                // Devolvemos un error con formato consistente
                var errorResponse = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = exception.Message,
                    Errors = new[] { exception.Message } // Aquí podrías estructurarlo de manera más detallada si es necesario
                };

                context.Result = new BadRequestObjectResult(errorResponse);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}
