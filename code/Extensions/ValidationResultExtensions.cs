using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FluentValidation
{ 
    public static class ValidationResultExtensions
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState, string? bindingPropertyName = null)
        {
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    if (String.IsNullOrEmpty(bindingPropertyName))
                    {
                        modelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                    else
                    {
                        modelState.AddModelError(bindingPropertyName + "." + error.PropertyName, error.ErrorMessage);
                    }
                }
            }
        }
    }
}
