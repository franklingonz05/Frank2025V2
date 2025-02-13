using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCard.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                // Reestructuramos los errores para que estén más organizados
                var errors = context.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .ToDictionary(
                        e => e.Key,
                        e => e.Value.Errors.Select(x => x.ErrorMessage).ToArray()
                    );

                // Devolvemos los errores de validación con el formato estructurado
                var result = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = "One or more validation errors occurred.",
                    Errors = errors
                };

                context.Result = new BadRequestObjectResult(result);
                return;
            }

            await next();
        }
    }
}
