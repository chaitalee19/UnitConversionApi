using System.Text.Json;

namespace UnitConversionApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(
            HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException ex)
            {
                context.Response.StatusCode = 400;

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(
                        new
                        {
                            Message = ex.Message
                        }));
            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(
                        new
                        {
                            Message = "An unexpected error occurred."
                        }));
            }
        }
    }
}