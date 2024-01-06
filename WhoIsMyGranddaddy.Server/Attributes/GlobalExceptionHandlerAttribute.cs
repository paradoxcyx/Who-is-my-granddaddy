
using WhoIsMyGranddaddy.Server.Shared.Models;

namespace WhoIsMyGranddaddy.Server.Attributes;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class GlobalExceptionHandlerAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        // Create error response with the generic response model
        var errorResponse = new GenericResponseModel<object?>
        {
            Success = false,
            Message = context.Exception.Message,
            Data = null
        };

        // Set the response to a json object
        context.Result = new ObjectResult(errorResponse)
        {
            StatusCode = 500,
            DeclaredType = typeof(GenericResponseModel<object?>)
        };
    }
}
