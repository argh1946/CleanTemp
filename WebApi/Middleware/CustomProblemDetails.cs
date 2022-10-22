using FluentResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System;


public static class CustomProblemDetails
{
    public static IActionResult MakeValidationResponse(ActionContext context)
    {
        Result result = new Result();
        foreach (var keyModelStatePair in context.ModelState)
        {
            var errors = keyModelStatePair.Value.Errors;
            if (errors != null && errors.Count > 0)
            {
                for (var i = 0; i < errors.Count; i++)
                {
                    result.WithError(GetErrorMessage(errors[i]));                   
                }
            }
        }
        var res = new BadRequestObjectResult(result);
        res.ContentTypes.Add("application/problem+json");
        return res;
    }
    static string GetErrorMessage(ModelError error)
    {
        return string.IsNullOrEmpty(error.ErrorMessage) ? "The input was not valid." : error.ErrorMessage;
    }
}

