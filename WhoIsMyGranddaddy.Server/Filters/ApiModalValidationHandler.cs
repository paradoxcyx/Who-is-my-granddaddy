using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WhoIsMyGranddaddy.Server.Shared.Models;

namespace WhoIsMyGranddaddy.Server.Filters;

public class ApiModalValidationHandler<T> : ObjectResult
{
    public ApiModalValidationHandler(ActionContext context) : base(new GenericResponseModel<T?>
    {
        Success = false,
        Data = default,
        Paging = null
    })
    {
        ConstructErrorMessages(context);
        StatusCode = 500;
    }

    /// <summary>
    /// Constructing the error messages from the validation context
    /// </summary>
    /// <param name="context">The action context</param>
    private void ConstructErrorMessages(ActionContext context)
    {
        var responseModel = Value as GenericResponseModel<T>;

        //Iterate through the modal state to find all errors and join with ',' to display on front-end
        foreach (var (_, value) in context.ModelState)
        {
            var errors = value.Errors;
            var errorMessages = new string[errors.Count];
            for (var i = 0; i < errors.Count; i++)
            {
                errorMessages[i] = GetErrorMessage(errors[i]);
            }
            responseModel!.Message = string.Join(", ", errorMessages);
        }
    }
    
    /// <summary>
    /// Retrieving plain error message
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    private static string GetErrorMessage(ModelError error)
    {
        return error.ErrorMessage;
    }
}