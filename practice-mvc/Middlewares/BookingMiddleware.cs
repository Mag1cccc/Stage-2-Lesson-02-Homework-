namespace Practice_MVC.Middlewares
{
    public class BookingMiddleware 
    {
        private readonly RequestDelegate _next;

        public BookingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value.Contains("/comschool"))
            {
                await context.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes("Hello"));
            }
        }

    }
}
