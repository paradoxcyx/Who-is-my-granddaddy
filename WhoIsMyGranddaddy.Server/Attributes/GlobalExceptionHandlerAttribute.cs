
using WhoIsMyGranddaddy.Server.Shared.Models;

namespace WhoIsMyGranddaddy.Server.Attributes;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class GlobalExceptionHandlerAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        // Error response using the Generic Response Model
        var errorResponse = new GenericResponseModel<object?>
        {
            Success = false,
            Message = context.Exception.Message,
            Data = null
        };

        // The the response to the context result
        context.Result = new ObjectResult(errorResponse)
        {
            StatusCode = 500,
            DeclaredType = typeof(GenericResponseModel<object?>)
        };
    }
}
