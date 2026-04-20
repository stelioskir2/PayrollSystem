using System.Net;
using System.Text.Json;
using PayrollSystem.Helpers;

namespace PayrollSystem.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);  // συνέχισε κανονικά
            }
            catch (Exception ex)
            {
                // κάτι πήγε στραβά — πιάσε το εδώ
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                var response = new ApiResponse
                {
                    Success = false,
                    StatusCode = 500,
                    Message = "Κάτι πήγε στραβά: " + ex.Message,
                    Data = null
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}