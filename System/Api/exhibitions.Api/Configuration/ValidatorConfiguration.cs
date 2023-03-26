using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using exhibition.Common.Helpers;
using exhibition.Common.Responses;
using exhibition.Common.Validator;
using exhibition.Common.Extensions;
using FluentValidation.AspNetCore;

namespace Api.Configuration
{
    public static class ValidatorConfiguration
    {
        public static IMvcBuilder AddValidator(this IMvcBuilder builder)
        {
            builder.ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var fieldErrors = new List<ErrorResponseFieldInfo>();
                    foreach (var (field, state) in context.ModelState)
                    {
                        if (state.ValidationState == ModelValidationState.Invalid)
                            fieldErrors.Add(new ErrorResponseFieldInfo()
                            {
                                FieldName = field.ToCamelCase(),
                                Message = string.Join(", ", state.Errors.Select(x => x.ErrorMessage))
                            });
                    }

                    var result = new BadRequestObjectResult(new ErrorResponse()
                    {
                        ErrorCode = 100,
                        Message = "One or more validation errors occurred.",
                        FieldErrors = fieldErrors
                    });

                    return result;
                };
            });

            builder.AddFluentValidation(fv =>
            {
                fv.DisableDataAnnotationsValidation = true;
                fv.ImplicitlyValidateChildProperties = true;
                fv.AutomaticValidationEnabled = true;
            });

            ValidatorsRegisterHelper.Register(builder.Services);

            builder.Services.AddSingleton(typeof(IModelValidator<>), typeof(ModelValidator<>));

            return builder;
        }
    }
}
