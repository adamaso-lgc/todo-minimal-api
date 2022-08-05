using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Todo.Api.Middlewares
{
    public class ValidationFailureResponse
    {
        public List<string> Errors { get; init; } = new();
    }

    public class ValidationExceptionMiddleware
    {
        private readonly RequestDelegate _request;

        public ValidationExceptionMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (ValidationException exception)
            {
                context.Response.StatusCode = 400;
                var messages = exception.Errors.Select(x => x.ErrorMessage).ToList();
                var validationFailureResponse = new ValidationFailureResponse
                {
                    Errors = messages
                };
                await context.Response.WriteAsJsonAsync(validationFailureResponse);
            }
        }
    }
}