


using System.Text.Json;
using exhibition.Common.Exceptions;
using exhibition.Common.Extensions;
using exhibition.Common.Responses;

namespace Api.Middlewares
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionsMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            ErrorResponse response = null;
            try
            {
                await next.Invoke(context);
            }
            catch (ProcessException pe)
            {
                response = pe.ToErrorResponse();
            }
            catch (Exception pe)
            {
                response = pe.ToErrorResponse();
            }
            finally
            {
                if (response is not null)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    await context.Response.StartAsync();
                    await context.Response.CompleteAsync();
                }
            }
        }
    }
}
