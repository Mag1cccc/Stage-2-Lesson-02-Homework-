using Microsoft.AspNetCore.Mvc;

namespace Practice_MVC.Middlewares
{
    public class BookingMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public BookingMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var isBookingAllowed = _configuration.GetValue<bool>("Information:BookingNotAllowed");
            if (isBookingAllowed) 
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Booking is not allowed at this time.");
                return;
            }

            await _next(context);
        }

    }
}
