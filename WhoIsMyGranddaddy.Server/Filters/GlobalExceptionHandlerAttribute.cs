using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WhoIsMyGranddaddy.Server.Shared.Models;

namespace WhoIsMyGranddaddy.Server.Filters
{
    public class GlobalExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            // Handle other exceptions with a generic response
            var errorResponse = new GenericResponseModel<object?>
            {
                Success = false,
                Message = context.Exception.Message,
                Data = null
            };

            context.Result = new ObjectResult(errorResponse)
            {
                StatusCode = 500,
                DeclaredType = typeof(GenericResponseModel<object?>)
            };
        }
    }
}
